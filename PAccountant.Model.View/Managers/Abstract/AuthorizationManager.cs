using PAccountant.Model.Entity;
using PAccountant.Model.View.Managers.StaticClasses;
using PAccountant.Model.View.Models.ClientModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PAccountant.Model.View.Managers.Abstract
{
    public abstract class AuthorizationManager
    {

        private CryptographyManager cryptography;

        protected CryptographyManager Cryptography
        {
            get { return cryptography; }
            set { cryptography = value; }
        }

        public AuthorizationManager()
        {
            Cryptography = DIManager.CryptographyManager;
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="model">User name and password</param>
        /// <returns>If authorization is successfull</returns>
        public abstract bool Login(LoginModel model);

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="model">User name and password</param>
        /// <returns>If Registration is successfull</returns>
        public abstract bool Registration(RegisterModel model);

        /// <summary>
        /// Check user's data validity
        /// </summary>
        /// <param name="model">User name and password</param>
        /// <returns>If user data is valid</returns>
        protected virtual bool Validation(object model)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model);
            if (!Validator.TryValidateObject(model, context, results, true))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        protected bool userExists(string name, string password)
        {
            using (var unit = DIManager.UnitOfWork)
            {

                var user = unit.Repository.GetALL<User>().FirstOrDefault(x=>x.UserName== name);
                if (user != null)
                {
                    if (Cryptography.CheckingEquals(user.Password, password))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        protected abstract void userAthorization(string name);

        public abstract void LogOff();
    }
}
