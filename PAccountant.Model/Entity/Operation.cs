//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PAccountant.DataLayer.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Operation
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Summ { get; set; }
        public string Commentary { get; set; }
        public int UserId { get; set; }
        public int SourceId { get; set; }
        public int CategoryId { get; set; }
        public int CurrencyId { get; set; }
        public int OperationTypeId { get; set; }
    
        public virtual Currency Currency { get; set; }
        public virtual OperationCategory OperationCategory { get; set; }
        public virtual OperationSource OperationSource { get; set; }
        public virtual OperationType OperationType { get; set; }
        public virtual User User { get; set; }
    }
}
