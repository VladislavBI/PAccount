using BussinessLogic.ViewManagers.Abstract.Debts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAccountant.Model.View.Areas.Debts.Controllers
{
    public class AgentController : Controller
    {
        IAgentsManager _agentManager;

        public AgentController(IAgentsManager agentManagerParam)
        {
            _agentManager = agentManagerParam;
        }
        // GET: Debts/Agent
        public ActionResult GetAgentsList()
        {
            return Json(_agentManager.GetAllInList(), JsonRequestBehavior.AllowGet);
        }
    }
}