using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Model
{
    public class ExtremumsModelsList
    {
        public List<ExtremumModel> ExtremumsList { get; set; }
        public ExtremumsModelsList()
        {
            ExtremumsList = new List<ExtremumModel>();
        }

    }
    public class ExtremumModel
    {
        public string ExtremumCategory { get; set; }
        public double Summ { get; set; }
        public string ExtremumName { get; set; }
    }
}
