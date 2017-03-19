using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Model
{
    public class AddOperationModel
    {
        public bool IsAddOperation { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Currency { get; set; }
        public double CurrencyRate { get; set; }
        [Required]
        [Range(0.0, double.MaxValue)]
        public double Summ { get; set; }
        public string Commentary { get; set; }
        public TemplateModel Template { get; set; }

    }
}
