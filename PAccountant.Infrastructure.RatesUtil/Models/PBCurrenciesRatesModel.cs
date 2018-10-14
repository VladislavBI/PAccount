using Newtonsoft.Json;

namespace PAccountant.Infrastructure.RatesUtil.Models
{
    public class PBCurrenciesRatesModel: CurrenciesRatesModel
    {
        [JsonProperty("base_ccy")]
        public override string CurrencyFrom { get; set; }
        [JsonProperty("ccy")]
        public override string CurrencyTo { get; set; }
        [JsonProperty("buy")]
        public override double BuyRate { get; set; }
        [JsonProperty("sale")]
        public override double SaleRate { get; set; }
    }
}
