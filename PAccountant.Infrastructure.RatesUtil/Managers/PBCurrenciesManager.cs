using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PAccountant.Infrastructure.RatesUtil.Helpers;
using PAccountant.Infrastructure.RatesUtil.Infrastructure;
using PAccountant.Infrastructure.RatesUtil.Models;

namespace PAccountant.Infrastructure.RatesUtil.Managers
{
    public class PBCurrenciesManager : ICurrenciesManager
    {
        private IRatesDataGetter _ratesGetter;
        private IConvertHelper _convertHelper;
        public PBCurrenciesManager()
        {
            _ratesGetter = SourceClassesFactory.Get(SourcesEnum.PrivatBank);
            _convertHelper = new UAHConvertHelper();
        }
        public double ChangeBuyRateForCurrency(double mainCurrencyAmount, string mainCurrency, string currencyForBuy)
        {
            throw new NotImplementedException();
        }

        public List<CurrencyFullModel> GetAllCurrenciesRates()
        {
            throw new NotImplementedException();
        }

        public double GetCertainCurrencyBuy(string currencyToGet, string currencyToCompare = "")
        {
            throw new NotImplementedException();
        }

        public CurrencyFullModel GetCertainCurrencyRates(string currencyToGet, string currencyToCompare = "")
        {
            throw new NotImplementedException();
        }

        public double GetCertainCurrencySell(string currencyToGet, string currencyToCompare = "")
        {
            throw new NotImplementedException();
        }

        public List<FinanceOperationModel> SetOneCurrencyForAllOperations(List<FinanceOperationModel> operationsListParam, string currencyForSetParam)
        {
                Parallel.ForEach(operationsListParam, operation => operation = TransferOperationToOtherCurrency(operation, currencyForSetParam));
                return operationsListParam;
        }

        public FinanceOperationModel TransferOperationToOtherCurrency(FinanceOperationModel operationParam, string currencyForSetParam)
        {
            if (string.Equals(operationParam.CurrencyName, currencyForSetParam, StringComparison.CurrentCultureIgnoreCase))
            {
                return operationParam;
            }

            var rates = _ratesGetter.GetCurrenciesRatesList();
            operationParam.Summ = _convertHelper.ConvertToOtherCurrency(operationParam, rates, currencyForSetParam);
            operationParam.SummDecimal = Convert.ToDecimal(operationParam.Summ);

            return operationParam;
        }
    }
}
