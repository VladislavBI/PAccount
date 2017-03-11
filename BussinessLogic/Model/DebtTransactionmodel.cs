using System;

namespace BussinessLogic.Model
{
    public class DebtTransactionModel
    {
        public int OperationId { get; set; }
        public double Sum { get; set; }
        public DateTime Date { get; set; }
    }
}