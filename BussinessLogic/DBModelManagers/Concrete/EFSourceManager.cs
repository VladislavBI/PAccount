using BussinessLogic.DBModelManagers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DBModelManagers.Concrete
{
    public class EFSourceManager : ISourcesDBManager
    {
        public void CreateEntityFromModel<TModel>(TModel modelParam)
        {
            throw new NotImplementedException();
        }

        public List<TModel> GetAllInModel<TModel>()
        {
            throw new NotImplementedException();
        }
    }
}
