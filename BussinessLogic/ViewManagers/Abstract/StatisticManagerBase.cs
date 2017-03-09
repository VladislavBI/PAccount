using BussinessLogic.Model;
using PAccountant.BussinessLogic.Infrastructure.Abstract;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.DataLayer.Entity;
using PAccountant.Model.Infrastructure.Abstract;
using RateScriptorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BussinessLogic.ViewManagers.Abstract
{
    public abstract class StatisticManagerBase
    {
        protected RateScriptor _rateManager;
        protected IUnitOfWork _unitOfWork;
        protected IMapperHelper _mapperManager;

        public StatisticManagerBase()
        {
            _rateManager = new RateScriptor();
            _mapperManager = DIManager.MapperHelper;
        }

        protected virtual List<OperationModel> GetMappedOperations()
        {
            
            using (var _unitOfWork = DIManager.UnitOfWork)
            {
                return _unitOfWork.PersonalAccountantContext.Set<Operation>()?.AsEnumerable().Select(x => new OperationModel
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
            }
        }
        public abstract double GetTotalBalance(string generalCurrency);

        public abstract IEnumerable<OperationsSumModel> GetCurrenciesOperationsSumm();
        public abstract object GetDetailedSourceInfo();

        public abstract object GetMonthStatistics();
    }
}
