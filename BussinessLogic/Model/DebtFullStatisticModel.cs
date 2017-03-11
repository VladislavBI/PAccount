using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Model
{
    public class DebtFullStatisticModel
    {
        public string Name { get; set; }
        public string DebtType { get; set; }
        public double AllSum { get; set; }
        public double LeftToReturn { get; set; }
        public DateTime EndDateFull { get; set; }
        public string EndDate { get {
                return EndDateFull.ToShortDateString();
            } }
        public string Comment { get; set; }
        public int Detailed { get; set; }
    }
}
