using BussinessLogic.Model;
using PAccountant.DataLayer.Entity;
using PAccountant.Infrastructure.RatesUtil.Managers;
using PAccountant.Infrastructure.RatesUtil.Models;
using PAccountant.Model.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BussinessLogic.ViewManagers.Abstract
{
    public abstract class ExtremumsManagerBase
    {

        protected IUnitOfWork _unitOfWork;
        protected ICurrenciesManager _rateScripter = new PBCurrenciesManager();

        public abstract ExtremumModel GetMaxOutcome();

        public abstract ExtremumModel GetMaxIncome();

        public abstract ExtremumModel GetMaxProfitableCategory();

        public abstract ExtremumModel GetMaxExpenditureCategory();

        public abstract ExtremumModel GetMaxProfitableSource();
        public abstract ExtremumModel GetMaxExpenditureSource();

        public abstract ExtremumModel GetMaxProfitableCurrency();
        public abstract ExtremumModel GetMaxExpenditureCurrency();
        
        /// <summary>
        /// Get max operation from the list
        /// </summary>
        /// <param name="operationListParam">list of operations to check</param>
        /// <param name="GetCurrentListCurrency">if - tre, get currency to change from </param>
        /// <returns>operation sum, id of operation from list and corrected sum</returns>
        protected virtual FinanceOperationModel GetMaxOperations(IEnumerable<IGrouping<string, Operation>> operationListParam, bool GetCurrentListCurrency = false)
        {
            FinanceOperationModel maxOperation = new FinanceOperationModel();
            foreach (var operation in operationListParam)
            {
                var financeOperationsList = operation.Select(x => new FinanceOperationModel()
                {
                    CurrencyName = x.Currency.Name,
                    OperationId = x.Id.ToString(),
                    Summ = Convert.ToDouble(x.Summ)
                }).ToList();
                var correctedSum = _rateScripter.SetOneCurrencyForAllOperations(financeOperationsList, GetCurrentListCurrency ? financeOperationsList.FirstOrDefault().CurrencyName : "USD").Sum(x => x.Summ);
                if (maxOperation.Summ < correctedSum)
                {
                    maxOperation.Summ = correctedSum;
                    maxOperation.CurrencyName = financeOperationsList.FirstOrDefault().CurrencyName;
                    maxOperation.OperationId = operation.FirstOrDefault().Id.ToString();
                }
            }
            return maxOperation;
        }
    }
}
