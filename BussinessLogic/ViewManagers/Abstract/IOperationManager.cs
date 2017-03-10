using BussinessLogic.DBModelManagers.Abstract;
using BussinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.ViewManagers.Abstract
{
    public interface IOperationManager
    {
        List<TotalFlowModel> GetMonthTotalFlow();
        List<TotalFlowWithDateModel> GetToTalFlowByMonth();
    }
    
}
