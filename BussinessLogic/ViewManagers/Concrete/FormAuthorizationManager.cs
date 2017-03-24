using BussinessLogic.Infrastructure.Concrete;
using BussinessLogic.Model;
using PAccountant.BussinessLogic.Managers.Abstract;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.DataLayer.Entity;
using PAccountant.Model.Infrastructure.Abstract;
using System.Web.Security;
using System;
using System.Linq;

namespace PAccountant.BussinessLogic.Managers.Concrete
{

    public class FormAuthorizationManager: AuthorizationManagerBase
    {
        IUnitOfWork _unitOfWork;
        public override bool Login(string name, byte[] password)
        {
            UserLoginModel model=CreateUserLoginModel(name, password);
            if (model != null)
            {
                userAthorization(model.Name);
                return true;
            }
            else
            {
                return false;
            }
        }
        private void CreateUser(UserLoginModel loginModel, IUnitOfWork unit)
        {
            //UserLoginModel loginModel = ReflectionManager.GetClassFromObject<UserLoginModel>(modelParam);
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
                    userAthorization(model.Name);
                    return true;
                }
               
            }
            return false;
        }

        protected override void userAthorization(string name)
        {
            using (_unitOfWork=DIManager.UnitOfWork)
            {
                var id = _unitOfWork.PersonalAccountantContext.Set<User>().FirstOrDefault(x => x.Name == name).Id.ToString();
                FormsAuthentication.SetAuthCookie(id, false);

            }
        }

        public override void LogOff()
        {
            FormsAuthentication.SignOut();
        }

        private static UserLoginModel CreateUserLoginModel(string name, byte[] password)
        {
            return new UserLoginModel { Name = name, Password = password };
        }
    }
}