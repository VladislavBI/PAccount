using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAccountant.DataLayer.Models
{
    public class other_Project
    {
        public int Id { get; set; }
        public double SumPerHour { get; set; }
        public double TotalHours { get; set; }
        public int UserId { get; set; }
        public int CurrencyId { get; set; }
        public string Name { get; set; }
        public bool IsEnded { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<other_FreelancePayement> other_FreelancePayement { get; set; }
        public virtual ICollection<other_SpendHoursPerProject> other_SpendHoursPerProject { get; set; }

    }
}
