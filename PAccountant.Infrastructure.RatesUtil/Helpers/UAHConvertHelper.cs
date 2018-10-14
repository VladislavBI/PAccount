using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAccountant.Infrastructure.RatesUtil.Models;

namespace PAccountant.Infrastructure.RatesUtil.Helpers
{
    class UAHConvertHelper : IConvertHelper
    {
        public double ConvertToOtherCurrency(FinanceOperationModel operationParam, IEnumerable<CurrenciesRatesModel> ratesParam, string currencyForSetParam)
        {
            if (IsConvertAvailable(operationParam, ratesParam, currencyForSetParam))
            {
                if (ratesParam.Any(x => string.Equals(x.CurrencyFrom, operationParam.CurrencyName, StringComparison.CurrentCultureIgnoreCase) 
                                     && string.Equals(x.CurrencyTo, currencyForSetParam, StringComparison.CurrentCultureIgnoreCase)))
                {
                    operationParam.Summ = operationParam.Summ /
                        ratesParam.FirstOrDefault(rate => string.Equals(rate.CurrencyFrom, operationParam.CurrencyName, StringComparison.CurrentCultureIgnoreCase)
                                                  && string.Equals(rate.CurrencyTo, currencyForSetParam, StringComparison.CurrentCultureIgnoreCase)).BuyRate;
                    return operationParam.Summ;
                }
                else
                {
                    operationParam.Summ = operationParam.Summ *
                        ratesParam.FirstOrDefault(rate => string.Equals(rate.CurrencyFrom, operationParam.CurrencyName, StringComparison.CurrentCultureIgnoreCase)
                                                  && string.Equals(rate.CurrencyTo, currencyForSetParam, StringComparison.CurrentCultureIgnoreCase)).SaleRate;
                    return operationParam.Summ;
                }
            }
            return 0;
        }

        public bool IsConvertAvailable(FinanceOperationModel operationParam, IEnumerable<CurrenciesRatesModel> ratesParam, string currencyForSetParam)
        {
            bool isAvailable = ratesParam.Any
                (x => string.Equals(x.CurrencyFrom, operationParam.CurrencyName, StringComparison.CurrentCultureIgnoreCase) 
                        && string.Equals(x.CurrencyTo, currencyForSetParam, StringComparison.CurrentCultureIgnoreCase)

                    || string.Equals(x.CurrencyTo, operationParam.CurrencyName, StringComparison.CurrentCultureIgnoreCase) 
                        && string.Equals(x.CurrencyFrom, currencyForSetParam, StringComparison.CurrentCultureIgnoreCase));
            if (!isAvailable)
            {
                throw new Exception($"OperationId {operationParam.OperationId} conversion from {operationParam.CurrencyName} to {currencyForSetParam} is not available");
            }
            else
            {
                return isAvailable;
            }
        }
    }
}
