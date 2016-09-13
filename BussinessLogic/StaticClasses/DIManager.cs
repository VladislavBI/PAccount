using BussinessLogic.Managers.Abstract;
using BussinessLogic.Managers.Concrete;
using PAccountant.BussinessLogic.Infrastructure.Abstract;
using PAccountant.BussinessLogic.Infrastructure.Concrete;
using PAccountant.BussinessLogic.Managers.Abstract;
using PAccountant.BussinessLogic.Managers.Concrete;
using PAccountant.Model.Infrastructure.Abstract;
using PAccountant.Model.Infrastructure.Concrete;

namespace PAccountant.BussinessLogic.StaticClasses
{
    public static class DIManager
    {

        public static IUnitOfWork UnitOfWork
        {
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

        public static IMapperManager MapperManager
        {
            get
            {
                return new AutoMapperManager();
            }
        }
        public static IAccountManager AccountManager
        {
            get
            {
                return new FormAccountManager();
            }
        }

    }
}