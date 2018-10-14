using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PAccountant.Infrastructure.RatesUtil.Infrastructure;
using PAccountant.Infrastructure.RatesUtil.Models;

namespace PAccountant.Infrastructure.RatesUtil.Helpers
{
    public class PBRatesDataGetter : IRatesDataGetter
    {
        public IEnumerable<CurrenciesRatesModel> GetCurrenciesRatesList()
        {
            string jsonString = GetRawDataFromSource().Result;
            return JsonConvert.DeserializeObject<IEnumerable<PBCurrenciesRatesModel>>(jsonString);
        }

        Task<string> GetRawDataFromSource()
        {
            var client = new HttpClient();
            var uri = new Uri(Consts.PrivatBankJsonUrl);

            return client.GetStringAsync(uri);
        }

    }
}
