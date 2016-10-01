using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DBModelManagers.Abstract
{
    public interface IDBManager
    {

        void CreateEntityFromModel<TModel>(TModel modelParam);
        List<NameIdClass> GetAllInList();
    }
}
