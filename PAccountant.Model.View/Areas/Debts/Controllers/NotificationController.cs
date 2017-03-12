using BussinessLogic.ViewManagers.Concrete.Debts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAccountant.Model.View.Areas.Debts.Controllers
{
    public class NotificationController : Controller
    {
        DebtsNotificationsManager _notificationManager;
        public NotificationController()
        {
            _notificationManager = new DebtsNotificationsManager();
        }
        // GET: Debts/Notification
        public ActionResult GetNotifications()
        {
            return Json(_notificationManager.GetNotifications(), JsonRequestBehavior.AllowGet);
        }
    }
}