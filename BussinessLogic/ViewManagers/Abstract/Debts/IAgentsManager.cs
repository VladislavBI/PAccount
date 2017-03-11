using BussinessLogic.Model;
using PAccountant.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.ViewManagers.Abstract.Debts
{
    public interface IAgentsManager: IListGetter
    {
        NameIdClassModel GetAgentWithCurrentName(string nameParam);
        debt_DebtAgent CreateNewInstance(string nameParam);
    }
}
