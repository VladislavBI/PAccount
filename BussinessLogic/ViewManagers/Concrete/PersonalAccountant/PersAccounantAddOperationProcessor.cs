using BussinessLogic.DBModelManagers.Abstract;
using BussinessLogic.Infrastructure.Concrete;
using BussinessLogic.Model;
using BussinessLogic.ViewManagers.Abstract;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.DataLayer.Entity;
using PAccountant.Model.Infrastructure.Abstract;
using System;
using System.Linq;

namespace BussinessLogic.ViewManagers.Concrete
{
    public class PersAccounantAddOperationProcessor : AddOperationProcessorBase<AddOperationModel, Operation>
    {
        public PersAccounantAddOperationProcessor(ICategoryManager categoryManagerParam, ISourceManager sourceManagerParam,
                                ICurrencyManager currencyManagerParam, IMapperManager mapperManagerParam, 
                                IDBManager dbManagerParam)
            : base(categoryManagerParam, sourceManagerParam, currencyManagerParam, mapperManagerParam, dbManagerParam)
        {
        }


        protected override void GetModelsForOperationOptions(AddOperationModel modelParam, DBModelManagers.Abstract.OperationType operationType, 
            out CurrencyNameIdRateClass currencyModel, out NameIdClassModel categoryModel, out NameIdClassModel sourceModel)
        {
            currencyModel = _currencyManager.GetCurrencyWithCurrentName(modelParam.Currency);
            categoryModel = _categoryManager.GetCategoryWithCurrentName(modelParam.Category,
operationType);
            sourceModel = _sourceManager.GetCategoryWithCurrentName(modelParam.Source);
        }

        /// <summary>
        /// Set ids for equal properties
        /// </summary>
        /// <param name="currencyModel"></param>
        /// <param name="categoryModel"></param>
        /// <param name="sourceModel"></param>
        /// <param name="modelForDb"></param>
        protected override void SetIdForForeignKeys(
            CurrencyNameIdRateClass currencyModel, 
            NameIdClassModel categoryModel,
            NameIdClassModel sourceModel, 
            string userName, 
            IUnitOfWork unitOfWork,
            DBModelManagers.Abstract.OperationType operationType,
            ref Operation operation)
        {
            if (currencyModel != null)
            {
                operation.CurrencyId = currencyModel.Id;
            }
            if (categoryModel != null)
            {
                operation.CategoryId = categoryModel.Id;
            }
            if (sourceModel != null)
            {
                operation.SourceId = sourceModel.Id;
            }
            operation.UserId = unitOfWork.PersonalAccountantContext.Set<User>().FirstOrDefault(x=>x.Name== userName).Id;

            operation.OperationTypeId = Convert.ToInt32(operationType);
        }

        public override bool addNewOperation(AddOperationModel modelParam, string userName)
        {
            if (modelParam != null && ValidationManager.modelIsValid(modelParam))
            {
                DBModelManagers.Abstract.OperationType operationType = modelParam.IsAddOperation ?
                    DBModelManagers.Abstract.OperationType.Income : DBModelManagers.Abstract.OperationType.Outcome;

                CurrencyNameIdRateClass currencyModel;
                NameIdClassModel categoryModel, sourceModel;
                GetModelsForOperationOptions(modelParam, operationType, out currencyModel, out categoryModel, out sourceModel);

                Operation newOperation = new Operation()
                {
                    Summ = Convert.ToDecimal(modelParam.Summ),
                    Date = modelParam.Date,
                    Commentary = modelParam.Commentary
                };
                SetIdForForeignKeys(currencyModel, categoryModel, sourceModel, userName, DIManager.UnitOfWork, operationType, ref newOperation);

                

                return true;
            }
            return false;
        }

        public override bool AddOperationToDB<TOPerationModel>(TOPerationModel operationToAdd)
        {
            {
                try
                {
                    //if we have different types of  operationToAddand operation
                    if (typeof(TOPerationModel) != typeof(Operation))
                    {
                        _dbManager.CreateEntityFromModelForPersAccount<TOPerationModel, Operation>(operationToAdd);
                    }
                    else
                    {
                        using (_unitOfWork = DIManager.UnitOfWork)
                        {
                            _unitOfWork.PersonalAccountantContext.Set<Operation>().Add(operationToAdd as Operation);
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
