using BussinessLogic.ViewManagers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.DBModelManagers.Abstract;
using BussinessLogic.Model;
using PAccountant.Model.Infrastructure.Abstract;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.DataLayer.Entity;
using PAccountant.BussinessLogic.Infrastructure.Abstract;
using RateScriptorLibrary;
using RateScriptorLibrary.ProgrammModel;

namespace BussinessLogic.ViewManagers.Concrete
{
    public class PersAccountCategoryManager : ICategoryManager
    {
        IUnitOfWork _unitOfWork;
        IMapperHelper _mapperManager;
        RateScriptor _scriptor;
        public PersAccountCategoryManager(IMapperHelper mapperManagerParam)
        {
            _mapperManager = mapperManagerParam;
            _scriptor = new RateScriptor();
        }
        public NameIdClassModel GetCategoryWithCurrentName(string nameParam)
        {
            throw new Exception();
        }

        public NameIdClassModel GetCategoryWithCurrentName(string nameParam, DBModelManagers.Abstract.OperationType operationTypeParam)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                int operationTypeId = Convert.ToInt32(operationTypeParam);
                OperationCategory contextCategory = _unitOfWork.PersonalAccountantContext.Set<OperationCategory>().
                    FirstOrDefault<OperationCategory>(x => x.Name.ToUpper() == nameParam.ToUpper() && x.OperationTypeId == operationTypeId);

                if (contextCategory == null)
                {
                    int Id = 0;
                    contextCategory = Int32.TryParse(nameParam, out Id) ?
                   _unitOfWork.PersonalAccountantContext.Set<OperationCategory>().FirstOrDefault(x => x.Id == Id && x.OperationTypeId == operationTypeId) :
                   CreateNewCategory(nameParam, operationTypeParam);
                }

                return _mapperManager.MapModel<OperationCategory, NameIdClassModel>(contextCategory);
            }
        }

        private OperationCategory CreateNewCategory(string nameParam, DBModelManagers.Abstract.OperationType operationTypeParam)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                _unitOfWork.PersonalAccountantContext.Set<OperationCategory>().Add(new OperationCategory() { Name = nameParam, OperationTypeId = Convert.ToInt32(operationTypeParam) });
                _unitOfWork.Save();
                return _unitOfWork.PersonalAccountantContext.Set<OperationCategory>().FirstOrDefault<OperationCategory>(x => x.Name.ToUpper() == nameParam.ToUpper());
            }
        }

        public dynamic GetAllInList(DBModelManagers.Abstract.OperationType operationType)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                return _unitOfWork.PersonalAccountantContext.Set<OperationCategory>().Where(x => x.OperationTypeId == (int)operationType)?.Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
            }
        }

        public List<TotalFlowWithDateModel> GetPeriodFlow(PeriodModel periodParam=null)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                bool hasPeriodParam = periodParam != null && periodParam.StartDate != new DateTime(1, 1, 1);
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
                    OperationId = x.OperationCategory.Name,
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
