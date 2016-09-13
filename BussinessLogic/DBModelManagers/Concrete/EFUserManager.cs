using System;
using System.Collections.Generic;
using BussinessLogic.DBModelManagers.Abstract;
using PAccountant.BussinessLogic.Infrastructure.Abstract;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.DataLayer.Entity;
using PAccountant.Model.Infrastructure.Abstract;

namespace BussinessLogic.DBModelManagers.Concrete
{
    public class EFUserManager: IUserDBManager<User>
    {
        IMapperManager _mapperManager;
        IUnitOfWork _unitOfWork;
        public EFUserManager()
        {
            _mapperManager = DIManager.MapperManager;
        }

        public void CreateEntityFromModel<TModel>(TModel modelParam)
        {
            User newUser = _mapperManager.MapModel<TModel, User>(modelParam);
            if (newUser!=null)
            {
                using (_unitOfWork = DIManager.UnitOfWork)
                {
                    _unitOfWork.Repository.Create(newUser);
                }
            }
           
        }

        public List<User> GetAllInList()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                return _unitOfWork.Repository.GetALL<User>();
            }
        }
    }
}
