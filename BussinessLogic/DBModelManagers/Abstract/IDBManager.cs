using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DBModelManagers.Abstract
{
    public enum OperationType
    {
        Income = 1,
        Outcome = 2
    }
    public interface IDBManager
    {

        void CreateEntityFromModelForPersAccount<TModel, TEntity>(TModel modelParam) where TEntity : class, new();
       
    }

}
