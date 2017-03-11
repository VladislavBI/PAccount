using BussinessLogic.Model;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.DataLayer.Entity;
using PAccountant.Model.Infrastructure.Abstract;
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
        public void AddTransaction(DebtTransactionModel model)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                _unitOfWork.PersonalAccountantContext.Set<debt_Transactions>().Add(new debt_Transactions
                {
                    Date = model.Date,
                    DebtOperationId = model.OperationId,
                    Sum = model.Sum
                });
                if (isDebtResovled(model.OperationId))
                {
                    _unitOfWork.PersonalAccountantContext.Set<debt_DebtOperations>().FirstOrDefault(x => x.Id == model.OperationId).IsInProgress = false;
                }
                _unitOfWork.Save();
            }
        }
        public List<DebtTransactionDetailedModel> GetTransactionsList(int operationId)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                PAccountantEntities context = _unitOfWork.PersonalAccountantContext as PAccountantEntities;
                if (context!=null)
                {
                    var a = context.debt_Transactions.Where(x => x.DebtOperationId == operationId).ToList();
                    var b = a.Select(x => new DebtTransactionDetailedModel
                    {
                        Date = x.Date,
                        Sum = x.Sum,
                        Left = x.debt_DebtOperations.StartSum + x.debt_DebtOperations.RewardSum - (a.Any(y=>y.Date<x.Date||(y.Date<=x.Date&&x.Id>=y.Id))? a.Where(y => y.Date < x.Date || (y.Date <= x.Date && x.Id >= y.Id)).Sum(y=>y.Sum):0)
                          
                    }).ToList();
                    return b;
                }
               
                return null;
            }
        }

        private bool isDebtResovled(int operationId)
        {
            return _unitOfWork.PersonalAccountantContext.Set<debt_DebtOperations>().
                Sum(x => x.StartSum + x.RewardSum -
                (x.debt_Transactions.Any() ?
                x.debt_Transactions.Sum(y => y.Sum)
                : 0)) <= 0;
        }
    }
}
