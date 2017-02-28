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

        void CreateEntityFromModel<TModel>(TModel modelParam);
        List<NameIdClass> GetAllInList();
        List<NameIdClass> GetAllInList(OperationType operationTypeParam);
        NameIdClass GetCategoryWithCurrentName(string nameParam);
        NameIdClass GetCategoryWithCurrentName(string nameParam, OperationType operationTypeParam);

    }

}
