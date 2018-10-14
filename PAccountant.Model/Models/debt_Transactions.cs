using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAccountant.DataLayer.Models
{
    public class debt_Transactions
    {
        public int Id { get; set; }
        public int DebtOperationId { get; set; }
        public double Sum { get; set; }
        public DateTime Date { get; set; }
        public virtual debt_DebtOperation Debt_DebtOperations { get; set; }

    }
}
