using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Model
{
    public class PersAccTemplateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CurrencyId { get; set; }
        public int SourceId { get; set; }
        public int CategoryId { get; set; }

        public DateTime Date { get; set; }
        public string Commentary { get; set; }
        float _sum;
        public float Sum
        {
            get
            {
                return _sum;
            }
            set
            {
                _sum = value;
            }
        }
        public decimal SumDecimal
        {
            get
            {
                return Convert.ToDecimal(_sum);
            }
            set
            {
                _sum = Convert.ToSingle(value);
            }
        }
    }
}
