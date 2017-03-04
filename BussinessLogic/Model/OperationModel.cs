using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Model
{
    public class OperationModel
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Summ { get; set; }
        public string Commentary { get; set; }
        public string Source { get; set; }
        public string Category { get; set; }
        public string Currency { get; set; }
    }
}
