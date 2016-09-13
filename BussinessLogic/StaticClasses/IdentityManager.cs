using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAccountant.BussinessLogic.StaticClasses
{
    public static class IdentityManager
    {
        public static string Name { get; set; }
        public static int Id { get; set; }

        public static bool IsAuthorized { get; set; }

        static IdentityManager()
        {
            IsAuthorized = false;
        }
    }
}