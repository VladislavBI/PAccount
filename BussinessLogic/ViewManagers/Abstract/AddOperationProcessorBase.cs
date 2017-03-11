using BussinessLogic.DBModelManagers.Abstract;
using BussinessLogic.Model;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.Model.Infrastructure.Abstract;
using System;

namespace BussinessLogic.ViewManagers.Abstract
{
    public abstract class AddOperationProcessorBase
    {

        protected IDBManager _dbManager;
        public AddOperationProcessorBase(IDBManager dbManagerParam)
        {

            _dbManager = dbManagerParam;
        }

        public abstract bool addNewOperation<TObject>(TObject modelParam, string userName) where TObject : class;


        protected abstract void GetModelsForOperationOptions<TObject, TModelForGet>(ref TObject modelParam,
            TModelForGet modelForGet) where TObject: class where TModelForGet: class;

        /// <summary>
        /// Set ids for equal properties
        /// </summary>
        /// <param name="currencyModel"></param>
        /// <param name="categoryModel"></param>
        /// <param name="sourceModel"></param>
        /// <param name="modelForDb"></param>
        protected abstract void SetIdForForeignKeys<TObject, TModelForSet>(
            TModelForSet modelsForSet,
            IUnitOfWork unitOfWork,
            ref TObject operationParam) where TObject : class;

        public abstract bool AddOperationToDB<TOPerationModel>(TOPerationModel operationToAdd) where TOPerationModel : class, new();
        
    }
}
