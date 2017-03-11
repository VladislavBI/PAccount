using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Model
{
    public class DebtTransactionDetailedModel
    {
        public DateTime Date { get; set; }
        public string DateString
        {
            get
            {
                return Date.ToShortDateString();
            }
        }
        public double Sum { get; set; }
        public double Left { get; set; }
    }
}
