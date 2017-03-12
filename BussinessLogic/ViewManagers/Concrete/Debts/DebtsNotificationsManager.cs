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
    public class DebtsNotificationsManager
    {
        IUnitOfWork _unitOfWork;
        static RateScriptor _rateScriptor;
        public DebtsNotificationsManager()
        {
            _rateScriptor = new RateScriptor();
        }
        public List<string> GetNotifications()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                PAccountantEntities context = _unitOfWork.PersonalAccountantContext as PAccountantEntities;
                var notificationsList = new List<string>();

                if (context != null)
                {
                    GetCreditPeriodEndedOperations(context, notificationsList);
                    GetCreditNotPayForToLong(context, notificationsList);
                    GetDebitPeriodEndedOperations(context, notificationsList);
                    GetDebitNotPayForToLong(context, notificationsList);
                }
                return notificationsList;

            }


        }

        private static void GetCreditNotPayForToLong(PAccountantEntities context, List<string> notificationsList)
        {
            var operationWithTwoLastTransactions = context.debt_DebtOperations.Where(x => x.EndDate < DateTime.Now && x.IsInProgress && x.DebtTypeId == 2).ToDictionary(x => x.Id, x => x.debt_Transactions.OrderBy(y => y.Date).Select(y => new
            {
                Date = y.Date,
                AgentName = x.debt_DebtAgent.Name,
                LeftSum = x.StartSum + x.RewardSum - x.debt_Transactions.Sum(z => z.Sum),
                TransactionSum = y.Sum,
                CurrencyName=y.debt_DebtOperations.Currency.Name
            }).Take(1));
            
            foreach (var operation in operationWithTwoLastTransactions)
            {
                if (operation.Value.Any() && (DateTime.Now-operation.Value.Max(x => x.Date)).TotalDays >= 28)
                {
                    var transactionValue = operation.Value.FirstOrDefault(x => x.Date == operation.Value.Max(y => y.Date));
                    notificationsList.Add("No return for too long period from " + transactionValue.AgentName + ". Last payment was mad "
                        + transactionValue.Date.ToShortDateString() + ":" +
                        String.Format("{0:0.00}", _rateScriptor.ChangeBuyRateForCurrency(transactionValue.TransactionSum, transactionValue.CurrencyName, "usd")) + "$"
                        + ". Agent Still Should pay " +
                        String.Format("{0:0.00}", _rateScriptor.ChangeBuyRateForCurrency(transactionValue.LeftSum, transactionValue.CurrencyName, "usd"))+"$");
                }
            }
        }

        private static void GetCreditPeriodEndedOperations(PAccountantEntities context, List<string> notificationsList)
        {
            var currencyModel = context.debt_DebtOperations.Where(x => x.EndDate < DateTime.Now && x.IsInProgress && x.DebtTypeId == 2).Select(x => new {
                AgentName = x.debt_DebtAgent.Name,
                CurrencyName = x.Currency.Name,
                ToPay = x.StartSum + x.RewardSum - (x.debt_Transactions.Any() ? x.debt_Transactions.Sum(y => y.Sum) : 0)
            }).ToList();
            var a = currencyModel.Select(x=>_rateScriptor.ChangeBuyRateForCurrency(x.ToPay, x.CurrencyName, "usd"));
            notificationsList.AddRange(currencyModel.Select(x => "End period has come for " + x.AgentName + ". Agent should pay " +
                                          String.Format("{0:0.00}", _rateScriptor.ChangeBuyRateForCurrency(x.ToPay, x.CurrencyName, "usd"))+"$").ToList());

        }
        private static void GetDebitNotPayForToLong(PAccountantEntities context, List<string> notificationsList)
        {
            var operationWithTwoLastTransactions = context.debt_DebtOperations.Where(x => x.EndDate < DateTime.Now && x.IsInProgress && x.DebtTypeId == 1).ToDictionary(x => x.Id, x => x.debt_Transactions?.OrderBy(y => y.Date).Select(y => new
            {
                Date = y.Date,
                AgentName = x.debt_DebtAgent.Name,
                LeftSum = x.StartSum + x.RewardSum - x.debt_Transactions.Sum(z => z.Sum),
                TransactionSum = y.Sum,
                CurrencyName = y.debt_DebtOperations.Currency.Name
            }).Take(1));
            foreach (var operation in operationWithTwoLastTransactions)
            {
                if (operation.Value.Any() && (DateTime.Now-operation.Value.Max(x => x.Date)).TotalDays >= 28)
                {
                    var transactionValue = operation.Value.FirstOrDefault(x => x.Date == operation.Value.Max(y => y.Date));
                    notificationsList.Add("You have not pay your debt to " + transactionValue.AgentName + " for long period. Last payment was mad "
                        + transactionValue.Date.ToShortDateString() + ":" +
                        String.Format("{0:0.00}", _rateScriptor.ChangeBuyRateForCurrency(transactionValue.TransactionSum, transactionValue.CurrencyName, "usd"))+"$" + ". Agent still should pay " +
                        String.Format("{0:0.00}", _rateScriptor.ChangeBuyRateForCurrency(transactionValue.LeftSum, transactionValue.CurrencyName, "usd"))+"$");
                }
            }
        }

        private static void GetDebitPeriodEndedOperations(PAccountantEntities context, List<string> notificationsList)
        {
            var currencyModel = context.debt_DebtOperations.Where(x => x.EndDate < DateTime.Now && x.IsInProgress && x.DebtTypeId == 1).Select(x => new {
                AgentName = x.debt_DebtAgent.Name,
                CurrencyName = x.Currency.Name,
                ToPay = x.StartSum + x.RewardSum - (x.debt_Transactions.Any() ? x.debt_Transactions.Sum(y => y.Sum) : 0)
            }).ToList();

            notificationsList.AddRange(currencyModel.Select(x => "You have  overdue debt to " + x.AgentName+ ". You should pay " +
                                             String.Format("{0:0.00}", _rateScriptor.ChangeBuyRateForCurrency(x.ToPay, x.CurrencyName, "usd")) + "$").ToList());
        }
    }


}
