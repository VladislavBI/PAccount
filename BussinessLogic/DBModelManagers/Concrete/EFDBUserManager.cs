using System;
using System.Collections.Generic;
using BussinessLogic.DBModelManagers.Abstract;
using PAccountant.BussinessLogic.Infrastructure.Abstract;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.DataLayer.Entity;
using PAccountant.Model.Infrastructure.Abstract;

namespace BussinessLogic.DBModelManagers.Concrete
{
    public class EFDBUserManager: DBManager<User>
    {
        public override NameIdClass GetCategoryWithCurrentName(string nameParam)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                NameIdClass exualCurrency = _unitOfWork.Repository.FirstOrDefault<NameIdClass>(x => x.Name.ToUpper() == nameParam.ToUpper());
                CreateNewInstance(nameParam, exualCurrency);
                return (exualCurrency) ?? _unitOfWork.Repository.FirstOrDefault<NameIdClass>(x => x.Name.ToUpper() == nameParam.ToUpper());
            }
        }
        private void CreateNewInstance(string nameParam, NameIdClass exualCurrency)
        {
            if (exualCurrency == null)
            {
                _unitOfWork.Repository.Create(new OperationCategory() { Name = nameParam });
                _unitOfWork.Save();
            }
        }
    }
}
