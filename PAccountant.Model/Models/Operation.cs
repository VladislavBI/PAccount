using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAccountant.DataLayer.Models
{
    public class Operation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Decimal Summ { get; set; }
        public string Commentary { get; set; }
        public int UserId { get; set; }
        public int SourceId { get; set; }
        public int CategoryId { get; set; }
        public int CurrencyId { get; set; }
        public int OperationTypeId { get; set; }
        public virtual OperationCategory OperationCategory { get; set; }
        public virtual OperationSource OperationSource { get; set; }
        public virtual OperationType OperationType { get; set; }
        public virtual User User { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual ICollection<template_Operations> template_Operations { get; set; }

    }
}
