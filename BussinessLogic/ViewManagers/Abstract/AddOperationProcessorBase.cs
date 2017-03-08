using BussinessLogic.DBModelManagers.Abstract;
using BussinessLogic.Model;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.Model.Infrastructure.Abstract;
using System;

namespace BussinessLogic.ViewManagers.Abstract
{
    public abstract class AddOperationProcessorBase<TAddOperation, TDBOperation>
        where TAddOperation : class
        where TDBOperation : class, new()
    {
        protected ICategoryManager _categoryManager;
        protected ISourceManager _sourceManager;
        protected IDBManager _dbManager;
        protected ICurrencyManager _currencyManager;
        protected IMapperManager _mapperManager;
        protected IUnitOfWork _unitOfWork;
        public AddOperationProcessorBase(ICategoryManager categoryManagerParam, ISourceManager sourceManagerParam,
                                ICurrencyManager currencyManagerParam, IMapperManager mapperManagerParam,
                                IDBManager dbManagerParam)
        {
            _categoryManager = categoryManagerParam;
            _sourceManager = sourceManagerParam;
            _currencyManager = currencyManagerParam;
            _mapperManager = mapperManagerParam;
            _dbManager = dbManagerParam;
        }

        public abstract bool addNewOperation(TAddOperation modelParam, string userName);


        protected abstract void GetModelsForOperationOptions(TAddOperation modelParam, DBModelManagers.Abstract.OperationType operationType,
            out CurrencyNameIdRateClass currencyModel, out NameIdClassModel categoryModel, out NameIdClassModel sourceModel);

        /// <summary>
        /// Set ids for equal properties
        /// </summary>
        /// <param name="currencyModel"></param>
        /// <param name="categoryModel"></param>
        /// <param name="sourceModel"></param>
        /// <param name="modelForDb"></param>
        protected abstract void SetIdForForeignKeys(
            CurrencyNameIdRateClass currencyModel,
            NameIdClassModel categoryModel,
            NameIdClassModel sourceModel,
            string userName,
            IUnitOfWork unitOfWork,
            DBModelManagers.Abstract.OperationType operationType,
            ref TDBOperation operation);

        public abstract bool AddOperationToDB<TOPerationModel>(TOPerationModel operationToAdd) where TOPerationModel : class, new();
        
    }
}
