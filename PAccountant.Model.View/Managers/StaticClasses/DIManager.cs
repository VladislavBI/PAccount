using PAccountant.Model.Infrastructure.Abstract;
using PAccountant.Model.Infrastructure.Concrete;
using PAccountant.Model.View.Managers.Abstract;
using PAccountant.Model.View.Managers.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAccountant.Model.View.Managers.StaticClasses
{
    public static class DIManager
    {
        
        public static IUnitOfWork UnitOfWork {
            get
            {
                return new EFUnitOfWork();
            }
        }
        public static CryptographyManager CryptographyManager
        {
            get
            {
                return new MD5CryptographyManager();
            }
        }

        public static AuthorizationManager AuthorizationManager
        {
            get
            {
                return new FormAuthorizationManager();
            }
        }
    }
}