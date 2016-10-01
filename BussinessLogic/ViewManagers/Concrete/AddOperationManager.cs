using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.ViewManagers.Concrete
{
    public class AddOperationManager
    {
    }
    public class AddOperationModel
    {
        public bool IsAddOperation { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; }

        public string Category { get; set; }

        public string Currency { get; set; }
        public double CurrencyRate { get; set; }

        public double Summ { get; set; }
        public string Commentary { get; set; }

    };
}
