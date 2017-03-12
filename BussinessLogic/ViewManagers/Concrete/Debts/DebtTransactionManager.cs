using BussinessLogic.Model;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.DataLayer.Entity;
using PAccountant.Model.Infrastructure.Abstract;
using RateScriptorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.ViewManagers.Concrete.Debts
{
    public class DebtTransactionManager
    {
        IUnitOfWork _unitOfWork;
        RateScriptor _rateScriptor => new RateScriptor();
        public void AddTransaction(DebtTransactionModel model)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                ChangeTransactionSumToMainOperationsCurrency(model);

                _unitOfWork.PersonalAccountantContext.Set<debt_Transactions>().Add(new debt_Transactions
                {
                    Date = model.Date,
                    DebtOperationId = model.OperationId,
                    Sum = model.Sum
                });
                _unitOfWork.Save();

            }
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                if (isDebtResovled(model.OperationId))
                {
                    _unitOfWork.PersonalAccountantContext.Set<debt_DebtOperations>().FirstOrDefault(x => x.Id == model.OperationId).IsInProgress = false;
                    _unitOfWork.Save();

                }
            }
        }

        private void ChangeTransactionSumToMainOperationsCurrency(DebtTransactionModel model)
        {
            string operationsCurrency = _unitOfWork.PersonalAccountantContext.Set<debt_DebtOperations>().FirstOrDefault(x => x.Id == model.OperationId).Currency.Name;
            model.Sum = _rateScriptor.ChangeBuyRateForCurrency(model.Sum, model.CurrencyName, operationsCurrency);
        }

        public List<DebtTransactionDetailedModel> GetTransactionsList(int operationId)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                PAccountantEntities context = _unitOfWork.PersonalAccountantContext as PAccountantEntities;
                if (context != null)
                {
                    var a = context.debt_Transactions.Where(x => x.DebtOperationId == operationId).ToList();
                    var b = a.Select(x => new DebtTransactionDetailedModel
                    {
                        Date = x.Date,
                        Sum = x.Sum,
                        Left = _rateScriptor.ChangeBuyRateForCurrency(x.debt_DebtOperations.StartSum + x.debt_DebtOperations.RewardSum - (a.Any(y => y.Date < x.Date || (y.Date <= x.Date && x.Id >= y.Id)) ? a.Where(y => y.Date < x.Date || (y.Date <= x.Date && x.Id >= y.Id)).Sum(y => y.Sum) : 0), x.debt_DebtOperations.Currency.Name, "usd")

                    }).ToList();
                    return b;
                }

                return null;
            }
        }

        private bool isDebtResovled(int operationId)
        {
            return _unitOfWork.PersonalAccountantContext.Set<debt_DebtOperations>().Where(x=>x.Id==operationId).Select(x => x.StartSum + x.RewardSum - (x.debt_Transactions.Any() ?
                 x.debt_Transactions.Sum(y => y.Sum)
                 : 0)).FirstOrDefault() <= 0;
        }
    }
}
