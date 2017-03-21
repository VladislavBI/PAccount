using BussinessLogic.ViewManagers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.Model;
using PAccountant.DataLayer.Entity;
using PAccountant.BussinessLogic.Infrastructure.Abstract;
using PAccountant.Model.Infrastructure.Abstract;
using PAccountant.BussinessLogic.StaticClasses;
using RateScriptorLibrary.ProgrammModel;
using RateScriptorLibrary;

namespace BussinessLogic.ViewManagers.Concrete.PersonalAccountant
{
    public class PersAccountSourceManager : ISourceManager
    {
        IUnitOfWork _unitOfWork;
        IMapperHelper _mapperManager;
        RateScriptor _scriptor;
        public PersAccountSourceManager(IMapperHelper mapperManagerParam)
        {
            _mapperManager = mapperManagerParam;
            _scriptor = new RateScriptor();
        }
        public OperationSource CreateNewInstance(string nameParam)
        {
            _unitOfWork.PersonalAccountantContext.Set<OperationSource>().Add(new OperationSource() { Name = nameParam });
            _unitOfWork.Save();
            return _unitOfWork.PersonalAccountantContext.Set<OperationSource>().FirstOrDefault<OperationSource>(x => x.Name.ToUpper() == nameParam.ToUpper());
        }


        public NameIdClassModel GetCategoryWithCurrentName(string nameParam)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                OperationSource contextSource = _unitOfWork.PersonalAccountantContext.Set<OperationSource>().FirstOrDefault(x => x.Name.ToUpper() == nameParam.ToUpper());
                if (contextSource == null)
                {
                    int Id = 0;
                    contextSource = Int32.TryParse(nameParam, out Id) ?
                        _unitOfWork.PersonalAccountantContext.Set<OperationSource>().FirstOrDefault(x => x.Id == Id) :
                        CreateNewInstance(nameParam);
                }

                return _mapperManager.MapModel<OperationSource, NameIdClassModel>(contextSource);
            }
        }
        public dynamic GetAllInList()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                return _unitOfWork.PersonalAccountantContext.Set<OperationSource>().Select(x => new
                {
                    id = x.Id,
                    Name = x.Name
                }).ToList();

            }
        }

        public List<TotalFlowWithDateModel> GetPeriodFlow(PeriodModel periodParam = null)
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
                        OperationId = x.OperationSource.Name,
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
