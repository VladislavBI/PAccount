using BussinessLogic.DBModelManagers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Model
{
    public class PersonalAccountForeignKeyForSetModels
    {
        public CurrencyNameIdRateClass CurrencyModel { get; set; }
        public NameIdClassModel CategoryModel { get; set; }
        public NameIdClassModel SourceModel { get; set; }
        public OperationType OperationType { get; set; }
        public string UserId { get; set; }
    }
    public class DebtForeignKeyForSetModels
    {
        public NameIdClassModel AgentModel { get; set; }
        public DebtTypeEnum DebtType { get; set; }
        public string UserId { get; set; }
    }
}
