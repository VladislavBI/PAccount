using BussinessLogic.Model;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.DataLayer.Entity;
using PAccountant.Model.Infrastructure.Abstract;
using RateScriptorLibrary;
using RateScriptorLibrary.ProgrammModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.ViewManagers.Abstract
{
    public abstract class ExtremumsManagerBase
    {

        protected IUnitOfWork _unitOfWork;
        protected RateScriptor _rateScripter = new RateScriptor();

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
                var correctedSum = _rateScripter.SetOneCurrencyForAllOperations(financeOperationsList, GetCurrentListCurrency ? financeOperationsList.FirstOrDefault().CurrencyName : "USd").Sum(x => x.Summ);
                if (maxOperation.Summ < correctedSum)
                {
                    maxOperation.Summ = correctedSum;
                    maxOperation.OperationId = operation.FirstOrDefault().Id.ToString();
                }
            }
            return maxOperation;
        }
    }
}
