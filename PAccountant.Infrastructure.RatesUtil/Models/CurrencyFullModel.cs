using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAccountant.Infrastructure.RatesUtil.Models
{
    public class CurrencyFullModel
    {
        public string CurrencyName { get; set; }
        public double? Buy { get; set; }
        public double? Sell { get; set; }
    }
}
