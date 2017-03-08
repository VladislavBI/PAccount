using BussinessLogic.Managers.Abstract;
using BussinessLogic.Model;
using PAccountant.BussinessLogic.StaticClasses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PAccountant.BussinessLogic.Managers.Abstract
{
    public abstract class AuthorizationManagerBase
    {

        protected CryptographyManager _cryptography;
        protected IAccountManager _accountManager;

        public AuthorizationManagerBase()
        {
            _cryptography = DIManager.CryptographyManager;
            _accountManager = DIManager.AccountManager;
        }

        /// <summary>
        /// Login user
        /// </summary>
        ///<param name="name">name of user</param>
        ///<param name="password">password of user</param>
        /// <returns>If authorization is successfull</returns>
        public abstract bool Login(string name, byte[] password);

        /// <summary>
        /// Register user
        /// </summary>
        ///<param name="name">name of user</param>
        ///<param name="password">password of user</param>
        /// <returns>If Registration is successfull</returns>
        public abstract bool Registration(string name, byte[] password);

        /// <summary>
        /// Check user's data validity
        /// </summary>
        /// <param name="model">User name and password</param>
        /// <returns>If user data is valid</returns>
       
        
     
        protected abstract void userAthorization(string name);

        public abstract void LogOff();
    }
}
