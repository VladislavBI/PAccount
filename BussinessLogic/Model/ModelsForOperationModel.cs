using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Model
{
    public class ModelsForPersonalOperationModel
    {
        public DBModelManagers.Abstract.OperationType OperationType { get; set; }
        public CurrencyNameIdRateClass CurrencyModel { get; set; }
        public NameIdClassModel CategoryModel { get; set; }
        public NameIdClassModel SourceModel { get; set; }
    }
    public class ModelsForDebtOperationModel
    {
        public NameIdClassModel AgentModel { get; set; }
    }
}
