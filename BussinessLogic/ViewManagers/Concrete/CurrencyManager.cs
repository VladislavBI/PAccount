﻿using BussinessLogic.ViewManagers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.Model;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.Model.Infrastructure.Abstract;
using PAccountant.DataLayer.Entity;
using PAccountant.BussinessLogic.Infrastructure.Abstract;
using PAccountant.Infrastructure.RatesUtil.Managers;
using PAccountant.Infrastructure.RatesUtil.Models;

namespace BussinessLogic.ViewManagers.Concrete
{
    public class CurrencyManager : ICurrencyManager
    {
        IUnitOfWork _unitOfWork;
        IMapperHelper _mapperHelper;
        ICurrenciesManager _scriptor;

        public CurrencyManager(IMapperHelper mapperHelperParam)
        {
            _mapperHelper = mapperHelperParam;
            _scriptor = new PBCurrenciesManager();
        }
        public CurrencyNameIdRateClass GetCurrencyWithCurrentName(string nameParam)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                Currency contextCurrency = _unitOfWork.PersonalAccountantContext.Set<Currency>().FirstOrDefault(x => x.Name.ToUpper() == nameParam.ToUpper());
                return _mapperHelper.MapModel<Currency, CurrencyNameIdRateClass>(contextCurrency);
            }
        }

        public dynamic GetAllInList()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                var a = _unitOfWork.PersonalAccountantContext.Set<Currency>().Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    Buy_Rate = x.Buy_Rate,
                    Sale_Rate = x.Sale_Rate
                }).ToList();
                return a;
            }
        }

        public List<TotalFlowWithDateModel> GetPeriodFlow(PeriodModel periodParam = null)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                bool hasPeriodParam = periodParam != null && periodParam.StartDate != new DateTime(1,1,1);
                DateTime? startPeriod = null;
                DateTime? endPeriod = null;
                if (hasPeriodParam)
                {
                    startPeriod = periodParam.StartDate;
                    endPeriod = periodParam.EndDate;
                }
                var financeOperationModel = _unitOfWork.PersonalAccountantContext.Set<Operation>().
                    Where(x => hasPeriodParam ?
                    x.Date >= startPeriod.Value && x.Date <= endPeriod.Value :
                    true)
                    .Select(x => new FinanceOperationModel
                    {
                        OperationId = x.Currency.Name,
                        CurrencyName = x.Currency.Name,
                        SummDecimal = x.OperationTypeId == 1 ? x.Summ : -1 * x.Summ
                    }).ToList();
                var on = _scriptor.SetOneCurrencyForAllOperations(financeOperationModel, "USD").Select(x => new TotalFlowWithDateModel
                {
                    IdentifyData = x.OperationId,
                    IncomeSum = x.Summ > 0 ? x.SummDecimal : 0,
                    OutcomeSum = x.Summ < 0 ? x.SummDecimal : 0
                }).GroupBy(x => x.IdentifyData).Select(y => new TotalFlowWithDateModel
                {
                    IdentifyData = y.Key,
                    IncomeSum = y.Sum(z => z.IncomeSum),
                    OutcomeSum = y.Sum(z => z.OutcomeSum) * -1
                }).Where(x => x.IncomeSum > 0 || x.OutcomeSum > 0).ToList();
                return on;
            }
        }
    }
}
