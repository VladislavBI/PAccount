using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAccountant.DataLayer.Models
{
    public class debt_DebtOperation
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public int UserId { get; set; }
        public int DebtTypeId { get; set; }
        public double StartSum { get; set; }
        public double RewardSum { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CurrencyId { get; set; }
        public string Comment { get; set; }
        public bool IsInProgress { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual debt_DebtAgent debt_DebtAgent { get; set; }
        public virtual debt_DebtType debt_DebtType { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<debt_Transactions> debt_Transactions { get; set; }

    }
}
