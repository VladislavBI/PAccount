using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DBModelManagers.Abstract
{
    public interface IMapperManager
    {
        IMapperManager Mapper { get; set; }
        List<TModel> GetAllInModel<TModel>();
    }
}
