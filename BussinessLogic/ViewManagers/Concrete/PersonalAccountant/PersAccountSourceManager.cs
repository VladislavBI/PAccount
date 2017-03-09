using BussinessLogic.ViewManagers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.Model;
using PAccountant.DataLayer.Entity;
using PAccountant.BussinessLogic.Infrastructure.Abstract;
using PAccountant.Model.Infrastructure.Abstract;
using PAccountant.BussinessLogic.StaticClasses;

namespace BussinessLogic.ViewManagers.Concrete.PersonalAccountant
{
    public class PersAccountSourceManager : ISourceManager
    {
        IUnitOfWork _unitOfWork;
        IMapperHelper _mapperManager;
        public PersAccountSourceManager(IMapperHelper mapperManagerParam)
        {
            _mapperManager = mapperManagerParam;
        }
        public OperationSource CreateNewInstance(string nameParam)
        {
            _unitOfWork.PersonalAccountantContext.Set<OperationSource>().Add(new OperationSource() { Name = nameParam });
            _unitOfWork.Save();
            return _unitOfWork.PersonalAccountantContext.Set<OperationSource>().FirstOrDefault<OperationSource>(x => x.Name.ToUpper() == nameParam.ToUpper());
        }


        public NameIdClassModel GetCategoryWithCurrentName(string nameParam)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                OperationSource contextSource = _unitOfWork.PersonalAccountantContext.Set<OperationSource>().FirstOrDefault(x => x.Name.ToUpper() == nameParam.ToUpper());
                if (contextSource == null)
                {
                    int Id = 0;
                    contextSource = Int32.TryParse(nameParam, out Id) ?
                        _unitOfWork.PersonalAccountantContext.Set<OperationSource>().FirstOrDefault(x => x.Id == Id) :
                        CreateNewInstance(nameParam);
                }

                return _mapperManager.MapModel<OperationSource, NameIdClassModel>(contextSource);
            }
        }
        public dynamic GetAllInList()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                return _unitOfWork.PersonalAccountantContext.Set<OperationSource>().Select(x=>new {
                    id=x.Id,
                    Name=x.Name
                }).ToList();
                 
            }
        }
    }
}
