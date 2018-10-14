using PAccountant.Infrastructure.RatesUtil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAccountant.Infrastructure.RatesUtil.Managers
{
    public interface ICurrenciesManager
    {
        double ChangeBuyRateForCurrency(double mainCurrencyAmount, string mainCurrency, string currencyForBuy);
        List<CurrencyFullModel> GetAllCurrenciesRates();
        double GetCertainCurrencyBuy(string currencyToGet, string currencyToCompare = "");
        CurrencyFullModel GetCertainCurrencyRates(string currencyToGet, string currencyToCompare = "");
        double GetCertainCurrencySell(string currencyToGet, string currencyToCompare = "");
        List<FinanceOperationModel> SetOneCurrencyForAllOperations(List<FinanceOperationModel> operationsListParam, string currencyForSetParam);
        FinanceOperationModel TransferOperationToOtherCurrency(FinanceOperationModel operationParam, string currencyForSetParam);
    }
}
