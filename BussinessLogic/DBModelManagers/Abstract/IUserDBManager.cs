using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DBModelManagers.Abstract
{
    public interface IUserDBManager<TEntity>
    {
        void CreateEntityFromModel<TModel>(TModel modelParam);
        List<TEntity> GetAllInList();
    }
}
