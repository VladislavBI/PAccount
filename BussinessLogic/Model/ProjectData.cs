using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Model
{
    public class ProjectData
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public float TotalHours { get; set; }
        public float SumPerHour { get; set; }
        public int CurrencyId { get; set; }

    }
}
