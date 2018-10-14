using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAccountant.DataLayer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Password { get; set; }

        public virtual ICollection<Operation> Operations { get; set; }
        public virtual ICollection<debt_DebtOperation> debt_DebtOperations { get; set; }
        public virtual ICollection<other_Project> other_Projects { get; set; }

    }
}
