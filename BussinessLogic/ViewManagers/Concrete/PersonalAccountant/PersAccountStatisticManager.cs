using BussinessLogic.Model;
using BussinessLogic.ViewManagers.Abstract;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.DataLayer.Entity;
using PAccountant.Infrastructure.RatesUtil.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BussinessLogic.ViewManagers.Concrete.PersonalAccountant
{
    public class PersAccountStatisticManager : StatisticManagerBase
    {
        public override double GetTotalBalance(string generalCurrency)
        {
            var operationModelList = GetMappedOperations().Select(x => new FinanceOperationModel
            {
                OperationId = x.Id.ToString(),
                CurrencyName = x.Currency,
                Summ = Convert.ToDouble(x.Summ)
            }).ToList();

            var a = _rateManager.SetOneCurrencyForAllOperations(operationModelList, "usd");
            var b = a.Sum(x => x.Summ);
            return b;
        }
        public override IEnumerable<OperationsSumModel> GetCurrenciesOperationsSumm()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                //Second was adedd to increase if it is income or decrease if outcome
                return _unitOfWork.PersonalAccountantContext.Set<Operation>().AsEnumerable().GroupBy(x => x.Currency.Name).Select(x => new OperationsSumModel
                {
                    Name = x.Key,
                    Sum = x.Sum(y => y.OperationTypeId == 1 ? y.Summ : -y.Summ)
                }).ToList();
            }
        }
        public override object GetDetailedSourceInfo()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                var a = _unitOfWork.PersonalAccountantContext.Set<Operation>().AsEnumerable().GroupBy(x => new { x.SourceId, x.CurrencyId })
                    .Select(x => new
                    {
                        Source = _unitOfWork.PersonalAccountantContext.Set<OperationSource>().AsEnumerable().FirstOrDefault<OperationSource>(y => y.Id == x.Key.SourceId).Name,
                        Currency = _unitOfWork.PersonalAccountantContext.Set<Currency>().AsEnumerable().FirstOrDefault(y => y.Id == x.Key.CurrencyId).Name,
                        Summ = x.Sum(y => y.OperationTypeId == 1 ? y.Summ : -y.Summ)
                    }).ToList();
                return a;
            }
        }

        public override object GetMonthStatistics()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                return _unitOfWork.PersonalAccountantContext.Set<Operation>().AsEnumerable().Where(x => x.Date > DateTime.Today.AddMonths(-1)).Select(x => new
                {
                    Date = x.Date.ToShortDateString(),
                    Source = x.OperationSource.Name,
                    Category = x.OperationCategory.Name,
                    Currency = x.Currency.Name,
                    Summ = x.Summ,
                    Comment = x.Commentary
                }).ToList();
            }
        }
    }
}
