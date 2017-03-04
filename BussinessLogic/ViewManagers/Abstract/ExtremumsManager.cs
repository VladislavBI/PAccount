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
    public class ExtremumsManager
    {

        protected IUnitOfWork _unitOfWork;
        protected RateScriptor _rateScripter = new RateScriptor();

        public ExtremumModel GetMaxOutcome()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                var a = _unitOfWork.Repository.GetALL<Operation>().Where(x => x.OperationTypeId == 1).Select(x => new FinanceOperationModel
                {
                    CurrencyName = x.Currency.Name,
                    OperationId = x.Id.ToString(),
                    Summ = Convert.ToDouble(x.Summ)
                }).ToList();
                var b = _rateScripter.SetOneCurrencyForAllOperations(a, "USD");
                var c = b.Select(x => new ExtremumModel
                {
                    ExtremumCategory = "Max outcome",
                    Summ = x.Summ,
                    ExtremumName = x.CurrencyName
                }).FirstOrDefault(x => x.Summ == b.Max(y => y.Summ));
                return c;
            }
        }

        public ExtremumModel GetMaxIncome()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                var a = _unitOfWork.Repository.GetALL<Operation>().Where(x => x.OperationTypeId == 2).Select(x => new FinanceOperationModel
                {
                    CurrencyName = x.Currency.Name,
                    OperationId = x.Id.ToString(),
                    Summ = Convert.ToDouble(x.Summ)
                }).ToList();
                var b = _rateScripter.SetOneCurrencyForAllOperations(a, "USD");
                var c = b.Select(x => new ExtremumModel
                {
                    ExtremumCategory = "Max income",
                    Summ = x.Summ,
                    ExtremumName = x.CurrencyName
                }).FirstOrDefault(x => x.Summ == b.Max(y => y.Summ));
                return c;
            }
        }

        public ExtremumModel GetMaxProfitableCategory()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                var a = _unitOfWork.Repository.GetALL<Operation>().Where(x => x.OperationTypeId == 1).GroupBy(x => x.OperationCategory.Name);
                var c = GetMaxOperations(a);
                var d = new ExtremumModel
                {
                    ExtremumCategory = "Max profitable category",
                    Summ = c.Summ,
                    ExtremumName = _unitOfWork.Repository.GetALL<Operation>().FirstOrDefault(x => x.Id.ToString().Equals(c.OperationId)).OperationCategory.Name
                };

                return d;
            }
        }

        protected virtual FinanceOperationModel GetMaxOperations(IEnumerable<IGrouping<string, Operation>> operationListParam, bool GetCurrentListCurrency = false)
        {
            FinanceOperationModel maxOperations = new FinanceOperationModel();
            foreach (var item in operationListParam)
            {
                var operationsList = item.Select(x => new FinanceOperationModel()
                {
                    CurrencyName = x.Currency.Name,
                    OperationId = x.Id.ToString(),
                    Summ = Convert.ToDouble(x.Summ)
                }).ToList();
                var b = _rateScripter.SetOneCurrencyForAllOperations(operationsList, GetCurrentListCurrency ? operationsList.FirstOrDefault().CurrencyName : "USd").Sum(x => x.Summ);
                if (maxOperations.Summ < b)
                {
                    maxOperations.Summ = b;
                    maxOperations.OperationId = item.FirstOrDefault().Id.ToString();
                }
            }
            return maxOperations;
        }
        public ExtremumModel GetMaxExpenditureCategory()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                using (_unitOfWork = DIManager.UnitOfWork)
                {
                    var a = _unitOfWork.Repository.GetALL<Operation>().Where(x => x.OperationTypeId == 2).GroupBy(x => x.OperationCategory.Name);
                    var c = GetMaxOperations(a);
                    var d = new ExtremumModel
                    {
                        ExtremumCategory = "Max expenditure category",
                        Summ = c.Summ,
                        ExtremumName = _unitOfWork.Repository.GetALL<Operation>().FirstOrDefault(x => x.Id.ToString().Equals(c.OperationId)).OperationCategory.Name
                    };

                    return d;
                }

            }
        }

        public ExtremumModel GetMaxProfitableSource()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {

                var a = _unitOfWork.Repository.GetALL<Operation>().Where(x => x.OperationTypeId == 1).GroupBy(x => x.OperationSource.Name);
                var c = GetMaxOperations(a);
                var d = new ExtremumModel
                {
                    ExtremumCategory = "Max profitable source",
                    Summ = c.Summ,
                    ExtremumName = _unitOfWork.Repository.GetALL<Operation>().FirstOrDefault(x => x.Id.ToString().Equals(c.OperationId)).OperationCategory.Name
                };

                return d;

            }
        }
        public ExtremumModel GetMaxExpenditureSource()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {

                var a = _unitOfWork.Repository.GetALL<Operation>().Where(x => x.OperationTypeId == 2).GroupBy(x => x.OperationSource.Name);
                var c = GetMaxOperations(a);
                var d = new ExtremumModel
                {
                    ExtremumCategory = "Max expenditure source",
                    Summ = c.Summ,
                    ExtremumName = _unitOfWork.Repository.GetALL<Operation>().FirstOrDefault(x => x.Id.ToString().Equals(c.OperationId)).OperationCategory.Name
                };

                return d;
            }
        }

        public ExtremumModel GetMaxProfitableCurrency()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                var a = _unitOfWork.Repository.GetALL<Operation>().Where(x => x.OperationTypeId == 1).GroupBy(x => x.Currency.Name);
                var c = GetMaxOperations(a, true);
                var d = new ExtremumModel
                {
                    ExtremumCategory = "Max profitable currency",
                    Summ = c.Summ,
                    ExtremumName = _unitOfWork.Repository.GetALL<Operation>().FirstOrDefault(x => x.Id.ToString().Equals(c.OperationId)).OperationCategory.Name
                };

                return d;

            }
        }
        public ExtremumModel GetMaxExpenditureCurrency()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {

                var a = _unitOfWork.Repository.GetALL<Operation>().Where(x => x.OperationTypeId == 2).GroupBy(x => x.Currency.Name);
                var c = GetMaxOperations(a, true);
                var d = new ExtremumModel
                {
                    ExtremumCategory = "Max expenditure currency",
                    Summ = c.Summ,
                    ExtremumName = _unitOfWork.Repository.GetALL<Operation>().FirstOrDefault(x => x.Id.ToString().Equals(c.OperationId)).OperationCategory.Name
                };

                return d;

            }
        }
    }
}
