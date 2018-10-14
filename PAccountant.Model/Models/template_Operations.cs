using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAccountant.DataLayer.Models
{
    public class template_Operations
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OperationId { get; set; }

        public virtual Operation Operation { get; set; }
    }
}
