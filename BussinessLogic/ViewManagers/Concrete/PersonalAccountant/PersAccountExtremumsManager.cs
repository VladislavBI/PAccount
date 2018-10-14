using BussinessLogic.Model;
using BussinessLogic.ViewManagers.Abstract;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.DataLayer.Entity;
using PAccountant.Infrastructure.RatesUtil.Models;
using System;
using System.Linq;

namespace BussinessLogic.ViewManagers.Concrete.PersonalAccountant
{
    //HACK: sum is got for operation currency not main
    public class PersAccountExtremumsManager : ExtremumsManagerBase
    {
        public override ExtremumModel GetMaxOutcome()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                var outComeFinanceOperations = _unitOfWork.PersonalAccountantContext.Set<Operation>().AsEnumerable().Where(x => x.OperationTypeId == 2).Select(x => new FinanceOperationModel
                {
                    CurrencyName = x.Currency.Name,
                    OperationId = x.Id.ToString(),
                    Summ = Convert.ToDouble(x.Summ)
                }).ToList();
                var oneCurrencyOperationsList = _rateScripter.SetOneCurrencyForAllOperations(outComeFinanceOperations, "USD");
                return oneCurrencyOperationsList.Select(x => new ExtremumModel
                {
                    ExtremumCategory = "Max outcome",
                    Summ = x.Summ,
                    ExtremumName = x.CurrencyName
                }).FirstOrDefault(x => x.Summ == oneCurrencyOperationsList.Max(y => y.Summ));
            }
        }
        public override ExtremumModel GetMaxIncome()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                var incomeFinanceOperations = _unitOfWork.PersonalAccountantContext.Set<Operation>().AsEnumerable().Where(x => x.OperationTypeId == 1).Select(x => new FinanceOperationModel
                {
                    CurrencyName = x.Currency.Name,
                    OperationId = x.Id.ToString(),
                    Summ = Convert.ToDouble(x.Summ)
                }).ToList();
                var oneCurrencyOperationsList = _rateScripter.SetOneCurrencyForAllOperations(incomeFinanceOperations, "USD");
                return oneCurrencyOperationsList.Select(x => new ExtremumModel
                {
                    ExtremumCategory = "Max income",
                    Summ = x.Summ,
                    ExtremumName = x.CurrencyName
                }).FirstOrDefault(x => x.Summ == oneCurrencyOperationsList.Max(y => y.Summ));
            }
        }
        public override ExtremumModel GetMaxProfitableCategory()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                var incomeFinanceOperations = _unitOfWork.PersonalAccountantContext.Set<Operation>().Where(x => x.OperationTypeId == 1).GroupBy(x => x.OperationCategory.Name);
                var maxOperationModel = GetMaxOperations(incomeFinanceOperations);
                return new ExtremumModel
                {
                    ExtremumCategory = "Max profitable category",
                    Summ = maxOperationModel.Summ,
                    ExtremumName = _unitOfWork.PersonalAccountantContext.Set<Operation>().FirstOrDefault(x => x.Id.ToString().Equals(maxOperationModel.OperationId))?.OperationCategory.Name
                };
            }
        }
        public override ExtremumModel GetMaxExpenditureCategory()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                using (_unitOfWork = DIManager.UnitOfWork)
                {
                    var outcomeFinanceOperations = _unitOfWork.PersonalAccountantContext.Set<Operation>().Where(x => x.OperationTypeId == 2).GroupBy(x => x.OperationCategory.Name);
                    var maxOperationModel = GetMaxOperations(outcomeFinanceOperations);
                    return new ExtremumModel
                    {
                        ExtremumCategory = "Max expenditure category",
                        Summ = maxOperationModel.Summ,
                        ExtremumName = _unitOfWork.PersonalAccountantContext.Set<Operation>().FirstOrDefault(x => x.Id.ToString().Equals(maxOperationModel.OperationId))?.OperationCategory.Name
                    };
                }

            }
        }
        public override ExtremumModel GetMaxProfitableSource()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {

                var incomeFinanceOperations = _unitOfWork.PersonalAccountantContext.Set<Operation>().Where(x => x.OperationTypeId == 1).GroupBy(x => x.OperationSource.Name);
                var maxOperationModel = GetMaxOperations(incomeFinanceOperations);
                return new ExtremumModel
                {
                    ExtremumCategory = "Max profitable source",
                    Summ = maxOperationModel.Summ,
                    ExtremumName = _unitOfWork.PersonalAccountantContext.Set<Operation>().FirstOrDefault(x => x.Id.ToString().Equals(maxOperationModel.OperationId))?.OperationSource.Name
                };
            }
        }
        public override ExtremumModel GetMaxExpenditureSource()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {

                var outcomeFinanceOperations = _unitOfWork.PersonalAccountantContext.Set<Operation>().Where(x => x.OperationTypeId == 2).GroupBy(x => x.OperationSource.Name);
                var maxOperationModel = GetMaxOperations(outcomeFinanceOperations);
                return new ExtremumModel
                {
                    ExtremumCategory = "Max expenditure source",
                    Summ = maxOperationModel.Summ,
                    ExtremumName = _unitOfWork.PersonalAccountantContext.Set<Operation>().FirstOrDefault(x => x.Id.ToString().Equals(maxOperationModel.OperationId))?.OperationSource.Name
                };
            }
        }

        public override ExtremumModel GetMaxProfitableCurrency()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                var incomeFinanceOperations = _unitOfWork.PersonalAccountantContext.Set<Operation>().Where(x => x.OperationTypeId == 1).GroupBy(x => x.Currency.Name);
                var maxOperationModel = GetMaxOperations(incomeFinanceOperations);
                return new ExtremumModel
                {
                    ExtremumCategory = "Max profitable currency",
                    Summ = maxOperationModel.Summ,
                    ExtremumName = maxOperationModel.CurrencyName
                };
            }
        }
        public override ExtremumModel GetMaxExpenditureCurrency()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {

                var outcomeFinanceOperations = _unitOfWork.PersonalAccountantContext.Set<Operation>().Where(x => x.OperationTypeId == 2).GroupBy(x => x.Currency.Name);
                var maxOperationModel = GetMaxOperations(outcomeFinanceOperations, true);
                return new ExtremumModel
                {
                    ExtremumCategory = "Max expenditure currency",
                    Summ = maxOperationModel.Summ,
                    ExtremumName = _unitOfWork.PersonalAccountantContext.Set<Operation>().FirstOrDefault(x => x.Id.ToString().Equals(maxOperationModel.OperationId))?.Currency.Name
                };
            }
        }
    }
}
