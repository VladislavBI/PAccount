using PAccountant.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Managers.Abstract
{
    public interface IAccountManager
    {
        void CreateUserFromModel<TModel>(TModel modelParam);
        bool AnyUserMatchingCriteria(Predicate<User> expression);
        TModel GetModelForConcreteUser<TModel>(Predicate<User> expression) where TModel : new();
        bool userExists(string Name, byte[] password);
        string ReturnUserId(string userName);

    }
}
