using PAccountant.Infrastructure.RatesUtil.Models;
using System.Collections.Generic;

namespace PAccountant.Infrastructure.RatesUtil.Helpers
{
    public interface IRatesDataGetter
    {
        IEnumerable<CurrenciesRatesModel> GetCurrenciesRatesList();
    }
}
