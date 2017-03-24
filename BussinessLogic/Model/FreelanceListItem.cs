using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Model
{
    public class FreelanceListItem
    {
        public string Name { get; set; }
        public double FullHours { get; set; }
        public double SumPerHour { get; set; }
        double? _payedHours;
        public double? PayedHours
        {
            get
            {
                return _payedHours;
            }
            set
            {
                if (value.HasValue)
                {
                    _payedHours = value;
                }
                else
                {
                    _payedHours = 0;
                }
            }
        }
        double? _unpayedHours;

        public double? UnpayedHours
        {
            get
            {
                return _unpayedHours;
            }
            set
            {
                if (value.HasValue)
                {
                    _unpayedHours = value;
                }
                else
                {
                    _unpayedHours = 0;
                }
            }
        }
        public double PayedSum { get; set; }
        public int Id { get; set; }
        public bool IsEnded { get; set; }
    }
}
