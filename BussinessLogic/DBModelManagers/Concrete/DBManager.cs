using BussinessLogic.Model;
using PAccountant.BussinessLogic.Infrastructure.Abstract;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.DataLayer.Entity;
using PAccountant.Model.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DBModelManagers.Abstract
{

    public class EFDBManager : IDBManager
    {
        protected IMapperHelper _mapperManager;
        protected IUnitOfWork _unitOfWork;

        public EFDBManager()
        {
            _mapperManager = DIManager.MapperHelper;
        }



        /// <summary>
        /// Create new entity to DB from model
        /// </summary>
        /// <typeparam name="TModel">type of model to create from</typeparam>
        /// <typeparam name="TEntity">type of entity to create</typeparam>
        /// <param name="modelParam">instanst of model</param>
        public void CreateEntityFromModelForPersAccount<TModel, TEntity>(TModel modelParam) where TEntity :class, new()
        {
            TEntity newEntity = _mapperManager.MapModel<TModel, TEntity>(modelParam);
            if (newEntity != null)
            {
                using (_unitOfWork = DIManager.UnitOfWork)
                {
                    _unitOfWork.PersonalAccountantContext.Set<TEntity>().Add(newEntity);
                    _unitOfWork.Save();
                }
            }

        }
    }



}
