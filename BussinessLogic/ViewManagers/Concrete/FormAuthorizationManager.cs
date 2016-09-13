using BussinessLogic.Infrastructure.Concrete;
using BussinessLogic.Model;
using PAccountant.BussinessLogic.Managers.Abstract;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.DataLayer.Entity;
using PAccountant.Model.Infrastructure.Abstract;
using System.Web.Security;

namespace PAccountant.BussinessLogic.Managers.Concrete
{

    public class FormAuthorizationManager: AuthorizationManager
    {

        public override bool Login(string name, byte[] password)
        {
            UserLoginModel model=CreateUserLoginModel(name, password);
            if (model != null)
            {
                userAthorization(model.UserName);
                return true;
            }
            else
            {
                return false;
            }
        }
        private void CreateUser(object modelParam, IUnitOfWork unit)
        {
            UserLoginModel loginModel = ReflectionManager.GetClassFromObject<UserLoginModel>(modelParam);
            _accountManager.CreateUserFromModel<UserLoginModel>(loginModel);
        }

        public override bool Registration(string name, byte[] password)
        {
            UserLoginModel model = CreateUserLoginModel(name, password);
            if (model != null)
            {
                using (var unit = DIManager.UnitOfWork)
                {
                    CreateUser(model, unit);
                    userAthorization(model.UserName);
                    return true;
                }
               
            }
            return false;
        }

        protected override void userAthorization(string name)
        {
            FormsAuthentication.SetAuthCookie(name, false);
        }

        public override void LogOff()
        {
            FormsAuthentication.SignOut();
        }

        private static UserLoginModel CreateUserLoginModel(string name, byte[] password)
        {
            return new UserLoginModel { UserName = name, Password = password };
        }
    }
}