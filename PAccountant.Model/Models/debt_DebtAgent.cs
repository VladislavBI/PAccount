using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAccountant.DataLayer.Models
{
    public class debt_DebtAgent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<debt_DebtOperation> debt_DebtOperations { get; set; }

    }
}
