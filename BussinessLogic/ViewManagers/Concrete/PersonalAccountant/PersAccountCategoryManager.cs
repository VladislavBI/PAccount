using BussinessLogic.ViewManagers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.DBModelManagers.Abstract;
using BussinessLogic.Model;
using PAccountant.Model.Infrastructure.Abstract;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.DataLayer.Entity;
using PAccountant.BussinessLogic.Infrastructure.Abstract;

namespace BussinessLogic.ViewManagers.Concrete
{
    public class PersAccountCategoryManager : ICategoryManager
    {
        IUnitOfWork _unitOfWork;
        IMapperHelper _mapperManager;
        public PersAccountCategoryManager(IMapperHelper mapperManagerParam)
        {
            _mapperManager = mapperManagerParam;
        }
        public NameIdClassModel GetCategoryWithCurrentName(string nameParam)
        {
            throw new Exception();
        }

        public NameIdClassModel GetCategoryWithCurrentName(string nameParam, DBModelManagers.Abstract.OperationType operationTypeParam)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                int operationTypeId = Convert.ToInt32(operationTypeParam);
                OperationCategory contextCategory = _unitOfWork.PersonalAccountantContext.Set<OperationCategory>().
                    FirstOrDefault<OperationCategory>(x => x.Name.ToUpper() == nameParam.ToUpper() && x.OperationTypeId == operationTypeId);

                if (contextCategory == null)
                {
                    int Id = 0;
                    contextCategory = Int32.TryParse(nameParam, out Id) ?
                   _unitOfWork.PersonalAccountantContext.Set<OperationCategory>().FirstOrDefault(x => x.Id == Id && x.OperationTypeId == operationTypeId) :
                   CreateNewCategory(nameParam, operationTypeParam);
                }

                return _mapperManager.MapModel<OperationCategory, NameIdClassModel>(contextCategory);
            }
        }

        private OperationCategory CreateNewCategory(string nameParam, DBModelManagers.Abstract.OperationType operationTypeParam)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                _unitOfWork.PersonalAccountantContext.Set<OperationCategory>().Add(new OperationCategory() { Name = nameParam, OperationTypeId = Convert.ToInt32(operationTypeParam) });
                _unitOfWork.Save();
                return _unitOfWork.PersonalAccountantContext.Set<OperationCategory>().FirstOrDefault<OperationCategory>(x => x.Name.ToUpper() == nameParam.ToUpper());
            }
        }

        public dynamic GetAllInList(DBModelManagers.Abstract.OperationType operationType)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                return _unitOfWork.PersonalAccountantContext.Set<OperationCategory>().Where(x => x.OperationTypeId == (int)operationType)?.Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
            }
        }
    }
}
