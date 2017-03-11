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

namespace BussinessLogic.ViewManagers.Concrete.Debts
{
    public class DebtStatisticManager
    {
        IUnitOfWork _unitofWork;
        RateScriptor _rateScriptor;
        public DebtStatisticManager()
        {
            _rateScriptor = new RateScriptor();
        }
        public DebtsTotalsModel GetTotals()
        {
            DebtsTotalsModel debtTotalModel = new DebtsTotalsModel();
            using (_unitofWork = DIManager.UnitOfWork)
            {
                var CreditTotal = _unitofWork.PersonalAccountantContext.Set<debt_DebtOperations>().Where(x => x.DebtTypeId == 2 && x.IsInProgress)?.Select(x => new FinanceOperationModel
                {
                    CurrencyName = x.Currency.Name,
                    OperationId = x.Id.ToString(),
                    Summ = x.StartSum + x.RewardSum
                }).ToList();
                var DebitTotal = _unitofWork.PersonalAccountantContext.Set<debt_DebtOperations>().Where(x => x.DebtTypeId == 1 && x.IsInProgress)?.Select(x => new FinanceOperationModel
                {
                    CurrencyName = x.Currency.Name,
                    OperationId = x.Id.ToString(),
                    Summ = x.StartSum + x.RewardSum
                }).ToList();

                debtTotalModel.CreditTotal = _rateScriptor.SetOneCurrencyForAllOperations(CreditTotal, "USD").Sum(x => x.Summ);
                debtTotalModel.DebitTotal = _rateScriptor.SetOneCurrencyForAllOperations(DebitTotal, "USD").Sum(x => x.Summ);

            }
            return debtTotalModel;
        }

        public List<DebtFullStatisticModel> GetDebtTable()
        {
            using (_unitofWork = DIManager.UnitOfWork)
            {
                List<DebtFullStatisticModel> model = _unitofWork.PersonalAccountantContext.Set<debt_DebtOperations>().Where(x => x.IsInProgress)
                    .Select(x => new DebtFullStatisticModel
                    {
                        Name = x.debt_DebtAgent.Name,
                        DebtType = x.DebtTypeId == 1 ? "Debit" : "Credit",
                        AllSum = x.RewardSum + x.StartSum,
                        EndDateFull = x.EndDate,
                        LeftToReturn = x.RewardSum + x.StartSum - (x.debt_Transactions.Any() ? x.debt_Transactions.Sum(y => y.Sum) : 0),
                        Comment = x.Comment,
                        Detailed=x.Id
                    }).ToList();
                return model;
            }

        }
    }
}
