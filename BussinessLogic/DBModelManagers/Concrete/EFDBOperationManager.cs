using BussinessLogic.DBModelManagers.Abstract;
using PAccountant.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.Model;
using PAccountant.BussinessLogic.Infrastructure.Abstract;
using PAccountant.BussinessLogic.StaticClasses;

namespace BussinessLogic.DBModelManagers.Concrete
{
    public class EFDBOperationManager : DBManager<Operation>
    {
        IMapperManager _mapperManager;
        public EFDBOperationManager()
        {
            _mapperManager = DIManager.MapperManager;
        }
        public override NameIdClass GetCategoryWithCurrentName(string nameParam)
        {
            throw new NotImplementedException();
        }
    }
}
