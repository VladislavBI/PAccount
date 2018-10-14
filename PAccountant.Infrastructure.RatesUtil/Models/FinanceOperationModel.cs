using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAccountant.Infrastructure.RatesUtil.Models
{
    public class FinanceOperationModel
    {
        public string CurrencyName { get; set; }
        public string OperationId { get; set; }
        public double Summ { get; set; }
        public decimal SummDecimal { get; set; }
    }
}
