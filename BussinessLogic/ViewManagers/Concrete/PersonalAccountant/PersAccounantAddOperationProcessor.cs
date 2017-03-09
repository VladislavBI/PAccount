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
    public class PersAccounantAddOperationProcessor : AddOperationProcessorBase
    {
        public PersAccounantAddOperationProcessor(ICategoryManager categoryManagerParam, ISourceManager sourceManagerParam,
                                ICurrencyManager currencyManagerParam,
                                IDBManager dbManagerParam)
            : base(categoryManagerParam, sourceManagerParam, currencyManagerParam, dbManagerParam)
        {
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
                            _unitOfWork.Save();
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

        public override bool addNewOperation<TObject>(TObject modelParam, string userName)
        {
            AddOperationModel model = modelParam as AddOperationModel;
            if (model != null && model != null && ValidationManager.modelIsValid(model))
            {
                DBModelManagers.Abstract.OperationType operationType = model.IsAddOperation ?
                    DBModelManagers.Abstract.OperationType.Income : DBModelManagers.Abstract.OperationType.Outcome;

                CurrencyNameIdRateClass currencyModel = new CurrencyNameIdRateClass();
                NameIdClassModel categoryModel = new NameIdClassModel(), sourceModel = new NameIdClassModel();
                GetModelsForOperationOptions(operationType, ref model, ref currencyModel, ref categoryModel, ref sourceModel);

                Operation newOperation = new Operation()
                {
                    Summ = Convert.ToDecimal(model.Summ),
                    Date = model.Date,
                    Commentary = model.Commentary
                };
                SetIdForForeignKeys(currencyModel, categoryModel, sourceModel, userName, DIManager.UnitOfWork, operationType, ref newOperation);


                return AddOperationToDB(newOperation);
            }
            return false;
        }

        protected override void GetModelsForOperationOptions<TObject>(DBModelManagers.Abstract.OperationType operationType, ref TObject modelParam, ref CurrencyNameIdRateClass currencyModel, ref NameIdClassModel categoryModel, ref NameIdClassModel sourceModel)
        {
            AddOperationModel model = modelParam as AddOperationModel;
            if (model != null)
            {
                currencyModel = _currencyManager.GetCurrencyWithCurrentName(model.Currency);
                categoryModel = _categoryManager.GetCategoryWithCurrentName(model.Category,
    operationType);
                sourceModel = _sourceManager.GetCategoryWithCurrentName(model.Source);
            }
        }

        /// <summary>
        /// Set ids for equal properties
        /// </summary>
        /// <param name="currencyModel"></param>
        /// <param name="categoryModel"></param>
        /// <param name="sourceModel"></param>
        /// <param name="modelForDb"></param>
        protected override void SetIdForForeignKeys<TObject>(CurrencyNameIdRateClass currencyModel, NameIdClassModel categoryModel, NameIdClassModel sourceModel, string userName, IUnitOfWork unitOfWork, DBModelManagers.Abstract.OperationType operationType, ref TObject operationParam)
        {
            Operation operation = operationParam as Operation;
            if (operation != null)
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
                operation.UserId = unitOfWork.PersonalAccountantContext.Set<User>().FirstOrDefault(x => x.Name == userName).Id;

                operation.OperationTypeId = Convert.ToInt32(operationType);
            }
        }
    }
}
