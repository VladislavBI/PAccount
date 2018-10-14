using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAccountant.DataLayer.Models
{
    public class other_FreelancePayement
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public double HoursPayed { get; set; }
        public double SumPayed { get; set; }
        public DateTime PayDate { get; set; }
        public int CurrencyId { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual other_Project Other_Projects { get; set; }
    }
}
