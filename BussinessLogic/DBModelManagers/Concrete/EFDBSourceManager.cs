using BussinessLogic.DBModelManagers.Abstract;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.DataLayer.Entity;
using System;

namespace BussinessLogic.DBModelManagers.Concrete
{
    public class EFDBSourceManager:DBManager<OperationSource>
    {
        public override NameIdClass GetCategoryWithCurrentName(string nameParam)
        {

            using (_unitOfWork = DIManager.UnitOfWork)
            {
                OperationSource contextSource = _unitOfWork.Repository.FirstOrDefault<OperationSource>(x => x.Name.ToUpper() == nameParam.ToUpper());
                if (contextSource==null)
                {
                    int Id = 0;
                    contextSource = Int32.TryParse(nameParam, out Id) ?
                        _unitOfWork.Repository.FirstOrDefault<OperationSource>(x => x.Id == Id) :
                        CreateNewInstance(nameParam);
                }
               
                return _mapperManager.MapModel<OperationSource, NameIdClass>(contextSource);
            }
        }
        private OperationSource CreateNewInstance(string nameParam)
        {

            _unitOfWork.Repository.Create(new OperationSource() { Name = nameParam });
            _unitOfWork.Save();
            return _unitOfWork.Repository.FirstOrDefault<OperationSource>(x => x.Name.ToUpper() == nameParam.ToUpper());
        }
    }
}
