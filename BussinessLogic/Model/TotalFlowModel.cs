using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Model
{
    public class TotalFlowModel
    {
        public string OpeartionType { get; set; }
        public decimal OperationSum { get; set; }

    }
    public class TotalFlowWithDateModel
    {
        public string IdentifyData { get; set; }
        public decimal OutcomeSum { get; set; }
        public decimal IncomeSum { get; set; }

    }
}
