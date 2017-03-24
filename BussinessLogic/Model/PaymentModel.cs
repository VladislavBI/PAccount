using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Model
{
    public class PaymentModel
    {
        public int ProjectId { get; set; }
        public float PayedHours { get; set; }
        public float PayedSum { get; set; }
        public int CurrencyId { get; set; }
    }
}
