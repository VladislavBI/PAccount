using BussinessLogic.LogicManagers.State;
using BussinessLogic.Model;
using PAccountant.BussinessLogic.Infrastructure.Abstract;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.DataLayer.Entity;
using PAccountant.Model.Infrastructure.Abstract;
using PAccountant.Model.Infrastructure.Concrete;
using RateScriptorLibrary;
using RateScriptorLibrary.ProgrammModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.ViewManagers.Abstract
{
    public class StatisticManager
    {
        RateScriptor _rateManager;
        IDBStateManager _dbStateManager;
        IUnitOfWork _unitOfWork;
        IMapperManager _mapperManager;

        public StatisticManager()
        {
            _rateManager = new RateScriptor();
            _dbStateManager = DIManager.DBStateManager;
            _mapperManager = DIManager.MapperManager;
        }
        public List<OperationModel> GetMappedOperations()
        {
            using (var _unitOfWork = DIManager.UnitOfWork)
            {
                List<OperationModel> operationList = _unitOfWork.Repository.GetALL<Operation>()?.
                    Select(x => new OperationModel
                    {
                        Id = x.Id,
                        Category = x.OperationCategory.Name,
                        Commentary = x.Commentary,
                        Currency = x.Currency.Name,
                        Date = x.Date,
                        Source = x.OperationSource.Name,
                        Summ =
                        x.OperationType.Name == Enum.GetName(typeof(DBModelManagers.Abstract.OperationType),
                        DBModelManagers.Abstract.OperationType.Income) ? x.Summ : -1 * x.Summ
                    }).ToList();
                return operationList;

            }
        }
        public double GetTotalBalance(string generalCurrency)
        {
            var operationModelList = GetMappedOperations().Select(x => new FinanceOperationModel
            {
                OperationId = x.Id.ToString(),
                CurrencyName = x.Currency,
                Summ = Convert.ToDouble(x.Summ)
            }).ToList();

            return _rateManager.SetOneCurrencyForAllOperations(operationModelList, "usd").Sum(x => x.Summ);
        }

        public IEnumerable<OperationsSumModel> GetCurrenciesOperationsSumm()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                //Second was adedd to increase if it is income or decrease if outcome
                return _unitOfWork.Repository.GetALL<Operation>().GroupBy(x => x.Currency.Name).Select(x => new OperationsSumModel
                {
                    Name = x.Key,
                    Sum = x.Sum(y => y.OperationTypeId == 1 ? y.Summ : -y.Summ)
                }).ToList();
            }
        }
        public object GetDetailedSourceInfo()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                var a = _unitOfWork.Repository.GetALL<Operation>().GroupBy(x => new { x.SourceId, x.CurrencyId })
                    .Select(x => new
                    {
                        Source = _unitOfWork.Repository.FirstOrDefault<OperationSource>(y => y.Id == x.Key.SourceId).Name,
                        Currency = _unitOfWork.Repository.FirstOrDefault<Currency>(y => y.Id == x.Key.CurrencyId).Name,
                        Summ = x.Sum(y => y.OperationTypeId == 1 ? y.Summ : -y.Summ)
                    }).ToList();
                return a;
            }
        }

        public object GetMonthStatistics()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                return _unitOfWork.Repository.GetALL<Operation>().Where(x => x.Date > DateTime.Today.AddMonths(-1)).Select(x => new
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
