using BussinessLogic.DBModelManagers.Abstract;
using BussinessLogic.Model;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.Model.Infrastructure.Abstract;
using System;

namespace BussinessLogic.ViewManagers.Abstract
{
    public abstract class AddOperationProcessorBase
    {
        protected ICategoryManager _categoryManager;
        protected ISourceManager _sourceManager;
        protected ICurrencyManager _currencyManager;
        protected IUnitOfWork _unitOfWork;
        protected IDBManager _dbManager;
        public AddOperationProcessorBase(ICategoryManager categoryManagerParam, ISourceManager sourceManagerParam,
                                ICurrencyManager currencyManagerParam, IDBManager dbManagerParam)
        {
            _categoryManager = categoryManagerParam;
            _sourceManager = sourceManagerParam;
            _currencyManager = currencyManagerParam;
            _dbManager = dbManagerParam;
        }

        public abstract bool addNewOperation<TObject>(TObject modelParam, string userName) where TObject : class;


        protected abstract void GetModelsForOperationOptions<TObject>( DBModelManagers.Abstract.OperationType operationType, ref TObject modelParam,
            ref CurrencyNameIdRateClass currencyModel, ref NameIdClassModel categoryModel, ref NameIdClassModel sourceModel) where TObject: class;

        /// <summary>
        /// Set ids for equal properties
        /// </summary>
        /// <param name="currencyModel"></param>
        /// <param name="categoryModel"></param>
        /// <param name="sourceModel"></param>
        /// <param name="modelForDb"></param>
        protected abstract void SetIdForForeignKeys<TObject>(
            CurrencyNameIdRateClass currencyModel,
            NameIdClassModel categoryModel,
            NameIdClassModel sourceModel,
            string userName,
            IUnitOfWork unitOfWork,
            DBModelManagers.Abstract.OperationType operationType,
            ref TObject operation) where TObject : class;

        public abstract bool AddOperationToDB<TOPerationModel>(TOPerationModel operationToAdd) where TOPerationModel : class, new();
        
    }
}
