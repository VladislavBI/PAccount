using BussinessLogic.ViewManagers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.Model;
using PAccountant.Model.Infrastructure.Abstract;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.DataLayer.Entity;
using RateScriptorLibrary.ProgrammModel;
using RateScriptorLibrary;

namespace BussinessLogic.ViewManagers.Concrete.PersonalAccountant
{
    public class OperationManager : IOperationManager
    {
        IUnitOfWork _unitOfWork;
        RateScriptor _scriptor;
        public OperationManager()
        {
            _scriptor = new RateScriptor();
        }
        public List<TotalFlowModel> GetMonthTotalFlow()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                var financeOperationModel = _unitOfWork.PersonalAccountantContext.Set<Operation>().Select(x => new FinanceOperationModel
                {
                    OperationId = x.Id.ToString(),
                    CurrencyName = x.Currency.Name,
                    SummDecimal = x.OperationTypeId == 1 ? x.Summ : -1 * x.Summ
                }).ToList();
                return _scriptor.SetOneCurrencyForAllOperations(financeOperationModel, "USD").Select(x=> new TotalFlowModel {
                    OpeartionType=x.Summ>0?"Income":"Outcome",
                    OperationSum=x.Summ>0? x.SummDecimal: x.SummDecimal*-1
                }).GroupBy(x=>x.OpeartionType).Select(y=>new TotalFlowModel {
                    OpeartionType=y.Key,
                    OperationSum=y.Sum(z=>z.OperationSum)
                }).ToList();
            }
        }

        public List<TotalFlowWithDateModel> GetToTalFlowByMonth()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                var financeOperationModel = _unitOfWork.PersonalAccountantContext.Set<Operation>().Select(x => new FinanceOperationModel
                {
                    OperationId = x.Date.Month.ToString() + @"/" + x.Date.Year.ToString(),
                    CurrencyName = x.Currency.Name,
                    SummDecimal = x.OperationTypeId == 1 ? x.Summ : -1 * x.Summ
                }).ToList();
                var on = _scriptor.SetOneCurrencyForAllOperations(financeOperationModel, "USD").Select(x => new TotalFlowWithDateModel
                {
                    IdentifyData=x.OperationId,
                    IncomeSum = x.Summ > 0 ? x.SummDecimal :0,
                    OutcomeSum = x.Summ < 0 ? x.SummDecimal : 0
                }).GroupBy(x =>x.IdentifyData).Select(y => new TotalFlowWithDateModel
                {
                    IdentifyData = y.Key,
                    IncomeSum = y.Sum(z => z.IncomeSum),
                    OutcomeSum = y.Sum(z => z.OutcomeSum)*-1
                }).ToList();
                return on;
            }
        }
    }
}
