using System;
using BussinessLogic.DBModelManagers.Abstract;
using PAccountant.DataLayer.Entity;
using PAccountant.BussinessLogic.StaticClasses;
using System.Collections.Generic;

namespace BussinessLogic.DBModelManagers.Concrete
{
    public class EFDBCategoryManager : DBManager<OperationCategory>
    {
        public override NameIdClass GetCategoryWithCurrentName(string nameParam, Abstract.OperationType operationType)
        {

            using (_unitOfWork = DIManager.UnitOfWork)
            {

                OperationCategory contextCategory = _unitOfWork.Repository.FirstOrDefault<OperationCategory>(x => x.Name.ToUpper() == nameParam.ToUpper() && x.OperationTypeId == Convert.ToInt32(operationType));

                if (contextCategory == null)
                {
                    int Id = 0;
                    contextCategory = Int32.TryParse(nameParam, out Id) ?
                   _unitOfWork.Repository.FirstOrDefault<OperationCategory>(x => x.Id == Id && x.OperationTypeId == Convert.ToInt32(operationType)) :
                   CreateNewInstance(nameParam, operationType);
                }

                return _mapperManager.MapModel<OperationCategory, NameIdClass>(contextCategory);
            }
        }
        public override NameIdClass GetCategoryWithCurrentName(string nameParam)
        {
            throw new Exception();
        }
        private OperationCategory CreateNewInstance(string nameParam, Abstract.OperationType operationType)
        {

            _unitOfWork.Repository.Create(new OperationCategory() { Name = nameParam, OperationTypeId = Convert.ToInt32(operationType) });
            _unitOfWork.Save();
            return _unitOfWork.Repository.FirstOrDefault<OperationCategory>(x => x.Name.ToUpper() == nameParam.ToUpper());
        }

        public override List<NameIdClass> GetAllInList(Abstract.OperationType operationTypeParam)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                int operationTypeId = Convert.ToInt32(operationTypeParam);
                var operationType = _unitOfWork.Repository.Where<OperationCategory>(x => x.OperationTypeId == operationTypeId);
                return _mapperManager.MapListModel<OperationCategory, NameIdClass>(operationType);
            }
        }
    }
}
