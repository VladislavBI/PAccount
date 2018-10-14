using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAccountant.DataLayer.Models
{
    public class other_SpendHoursPerProject
    {
        public int Id { get; set; }
        public double SpendHours { get; set; }
        public int ProjectId { get; set; }

        public virtual other_Project other_Projects { get; set; }
    }
}
