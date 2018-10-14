using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAccountant.DataLayer.Models
{
    public class other_sumStored
    {
        public int Id { get; set; }
        public Nullable<double> Sum { get; set; }
        public Nullable<int> UserId { get; set; }
    }
}
