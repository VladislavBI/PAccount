using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BussinessLogic.Model
{
    public class AddPlanToStoreWithUser: AddPlanToStoreModel
    {
        public int UserId { get; set; }
    }
}