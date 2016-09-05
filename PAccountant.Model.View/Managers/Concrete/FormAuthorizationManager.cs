using PAccountant.Model.Entity;
using PAccountant.Model.Infrastructure.Abstract;
using PAccountant.Model.Infrastructure.Concrete;
using PAccountant.Model.View.Managers.Abstract;
using PAccountant.Model.View.Managers.StaticClasses;
using PAccountant.Model.View.Models.ClientModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;

namespace PAccountant.Model.View.Managers.Concrete
{

    public class FormAuthorizationManager: AuthorizationManager
    {

        public override bool Login(LoginModel model)
        {
            if (Validation(model) && userExists(model.Name, model.Password))
            {
                using (var unit = DIManager.UnitOfWork)
                {
                    userAthorization(model.Name);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private void CreateUser(RegisterModel model, IUnitOfWork unit)
        {
            unit.Repository.Create<User>(
                                    new User
                                    {
                                        UserName = model.Name,
                                        Password = Cryptography.EncodingString(model.Password)
                                    });
            unit.Save();
        }

        public override bool Registration(RegisterModel model)
        {

            if (Validation(model) && !userExists(model.Name, model.Password))
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
            FormsAuthentication.SetAuthCookie(name, false);
        }

        public override void LogOff()
        {
            FormsAuthentication.SignOut();
        }
    }
}