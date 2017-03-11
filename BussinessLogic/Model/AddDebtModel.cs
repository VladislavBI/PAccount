using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BussinessLogic.Model
{
    public class AddDebtModel
    {
        public string AgentName { get; set; }
        public DebtTypeEnum DebtType { get; set; }
        public double StartSum { get; set; }
        public double RewardSum { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int CurrencyId { get; set; }
        public string Commentary { get; set; }
    }

    public enum DebtTypeEnum
    {
        Credit = 2,
        Debit = 1
    }
}