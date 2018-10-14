using System.Collections.Generic;

namespace PAccountant.DataLayer.Models
{
    public class OperationCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OperationTypeId { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
        public virtual OperationType OperationType { get; set; }
    }
}
