using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PAccountant.Infrastructure.RatesUtil.Models
{   
    public class CurrenciesRatesModel
    {
        public virtual string CurrencyFrom { get; set; }
        public virtual string CurrencyTo { get; set; }
        public virtual double BuyRate { get; set; }
        public virtual double SaleRate { get; set; }
    }
}
