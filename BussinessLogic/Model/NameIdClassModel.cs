using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Model
{
    public class NameIdClassModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
    public class CurrencyNameIdRateClass : NameIdClassModel
    {
        public double Buy_Rate { get; set; }
    }
}
