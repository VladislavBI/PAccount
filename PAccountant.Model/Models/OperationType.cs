using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAccountant.DataLayer.Models
{
    public class OperationType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
        public virtual ICollection<OperationCategory> OperationCategories { get; set; }

    }
}
