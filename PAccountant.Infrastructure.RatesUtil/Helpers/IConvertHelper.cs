using PAccountant.Infrastructure.RatesUtil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAccountant.Infrastructure.RatesUtil.Helpers
{
    interface IConvertHelper
    {
        bool IsConvertAvailable(FinanceOperationModel operationParam, IEnumerable<CurrenciesRatesModel> ratesParam, string currencyForSetParam);
        double ConvertToOtherCurrency(FinanceOperationModel operationParam, IEnumerable<CurrenciesRatesModel> ratesParam, string currencyForSetParam);
    }
}
