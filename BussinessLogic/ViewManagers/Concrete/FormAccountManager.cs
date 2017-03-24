using BussinessLogic.Managers.Abstract;
using BussinessLogic.Model;
using PAccountant.BussinessLogic.Infrastructure.Abstract;
using PAccountant.BussinessLogic.Managers.Abstract;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.DataLayer.Entity;
using PAccountant.Model.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Managers.Concrete
{
    public class FormAccountManager : IAccountManager
    {
        IMapperHelper _mapperManager;
        IUnitOfWork _unitOfWork;
        CryptographyManager _cryptography;
        public FormAccountManager()
        {
            _mapperManager = DIManager.MapperHelper;
            _cryptography = DIManager.CryptographyManager;
            UsersIdCache = new Dictionary<string, string>();
        }
        public void CreateUserFromModel<TModel>(TModel modelParam)
        {
            User userEntity = _mapperManager.MapModel<TModel, User>(modelParam);
            if (userEntity != null)
            {
                using (_unitOfWork = DIManager.UnitOfWork)
                {
                    _unitOfWork.PersonalAccountantContext.Set<User>().Add(userEntity);
                    _unitOfWork.Save();
                }
            }
        }

        public bool AnyUserMatchingCriteria(Predicate<User> expression)
        {
            return _unitOfWork.PersonalAccountantContext.Set<User>().Any(x => expression(x));
        }

        public TModel GetModelForConcreteUser<TModel>(Predicate<User> expression) where TModel : new()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                User tempUser = _unitOfWork.PersonalAccountantContext.Set<User>().FirstOrDefault<User>(x => expression(x));
                return _mapperManager.MapModel<User, TModel>(tempUser);
            }

        }

        public bool userExists(string Name, byte[] password)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                if (_unitOfWork.PersonalAccountantContext.Set<User>().AsEnumerable().Any(x => x.Name == Name && _cryptography.CheckingEquals(x.Password, password)))
                {
                    return true;
                }
                return false;
            }

        }
        public bool userExists(string Name)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                if (_unitOfWork.PersonalAccountantContext.Set<User>().AsEnumerable().Any(x => x.Name == Name))
                {
                    return true;
                }
                return false;
            }

        }
        public string ReturnUserId(string userName)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                if (userExists(userName))
                {
                    using (_unitOfWork = DIManager.UnitOfWork)
                    {
                        if (!UsersIdCache.ContainsKey(userName))
                        {
                            UsersIdCache[userName] = _unitOfWork.PersonalAccountantContext.Set<User>().AsEnumerable().FirstOrDefault(x => x.Name == userName).Id.ToString();
                        }
                        return UsersIdCache[userName];
                    }
                }
                return null;
            }
        }
        Dictionary<string, string> UsersIdCache { get; set; }
    }
}
