using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Managers.Abstract
{
    public interface IDBEntitiesManager<TEntity>
    {
        void Create();
    }
}
