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

    public abstract class DBManager<TEntity> : IDBManager
        where TEntity : class, new()
    {
        protected IMapperManager _mapperManager;
        protected IUnitOfWork _unitOfWork;

        public DBManager()
        {
            _mapperManager = DIManager.MapperManager;
        }
        /// <summary>
        /// Returns entity that is equal to mentioned name(or create new one)
        /// </summary>
        /// <param name="Name">name to check</param>
        /// <returns>entity object</returns>
        public abstract NameIdClass GetCategoryWithCurrentName(string nameParam);

        /// <summary>
        /// Returns model that is equal to mentioned name(or create new one)
        /// </summary>
        /// <param name="Name">name to check</param>
        /// <param name="operationTypeParam">type of operation</param>
        /// <returns>entity object</returns>
        public virtual NameIdClass GetCategoryWithCurrentName(string nameParam, OperationType operationTypeParam) { return null; }

        /// <summary>
        /// Create new entity to DB from model
        /// </summary>
        /// <typeparam name="TModel">type of model to create from</typeparam>
        /// <param name="modelParam">instanst of model</param>
        public virtual void CreateEntityFromModel<TModel>(TModel modelParam)
        {
            TEntity newUser = _mapperManager.MapModel<TModel, TEntity>(modelParam);
            if (newUser != null)
            {
                using (_unitOfWork = DIManager.UnitOfWork)
                {
                    _unitOfWork.Repository.Create(newUser);
                    _unitOfWork.Save();
                }
            }

        }

        /// <summary>
        /// Get names and ids of all 
        /// </summary>
        /// <returns>list of such properties</returns>
        public virtual List<NameIdClass> GetAllInList()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                List<TEntity> userDbList = _unitOfWork.Repository.GetALL<TEntity>();
                Type t = typeof(TEntity);
                return _mapperManager.MapListModel<TEntity, NameIdClass>(userDbList);
            }
        }

        public virtual List<NameIdClass> GetAllInList(OperationType operationTypeParam)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Model with names and ids of entity
    /// </summary>
    public class NameIdClass
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
