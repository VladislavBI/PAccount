using BussinessLogic.Model;
using RateScriptorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.ViewManagers.Abstract.Investment
{
    public abstract class PlanManagerBase
    {
        protected RateScriptor scriptor;
        public PlanManagerBase()
        {
            scriptor = new RateScriptor();
        }
        public abstract void AddPlan(AddPlanToStoreWithUser modelParam);
        public abstract void AddSum(SumUserModel modelParam);
        public abstract dynamic GetPlanes(int userIdParam);
        public abstract float GetStoredMoney(int userIdParam);

    }
}
