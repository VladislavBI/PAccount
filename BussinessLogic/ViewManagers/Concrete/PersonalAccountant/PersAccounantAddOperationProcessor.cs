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
        protected ICategoryManager _categoryManager;
        protected ISourceManager _sourceManager;
        protected ICurrencyManager _currencyManager;
        protected IUnitOfWork _unitOfWork;
        public PersAccounantAddOperationProcessor(ICategoryManager categoryManagerParam, ISourceManager sourceManagerParam,
                                ICurrencyManager currencyManagerParam,
                                IDBManager dbManagerParam)
            : base(dbManagerParam)
        {
            _categoryManager = categoryManagerParam;
            _sourceManager = sourceManagerParam;
            _currencyManager = currencyManagerParam;
        }

        public override bool AddOperationToDB<TOPerationModel>(TOPerationModel operationToAdd)
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

        public override bool addNewOperation<TObject>(TObject modelParam, string userName)
        {
            AddOperationModel model = modelParam as AddOperationModel;
            if (model != null && model != null && ValidationManager.modelIsValid(model))
            {
                DBModelManagers.Abstract.OperationType operationType = model.IsAddOperation ?
                    DBModelManagers.Abstract.OperationType.Income : DBModelManagers.Abstract.OperationType.Outcome;

                ModelsForPersonalOperationModel modelForOperation = new ModelsForPersonalOperationModel
                {
                    CategoryModel = new NameIdClassModel(),
                    CurrencyModel = new CurrencyNameIdRateClass(),
                    OperationType = operationType,
                    SourceModel = new NameIdClassModel()
                };
                GetModelsForOperationOptions(ref model, modelForOperation);

                Operation newOperation = new Operation()
                {
                    Summ = Convert.ToDecimal(model.Summ),
                    Date = model.Date,
                    Commentary = model.Commentary
                };
                PersonalAccountForeignKeyForSetModels fKModel = new PersonalAccountForeignKeyForSetModels
                {
                    CurrencyModel = modelForOperation.CurrencyModel,
                    CategoryModel = modelForOperation.CategoryModel,
                    SourceModel = modelForOperation.SourceModel,
                    UserName = userName,
                    OperationType = operationType
                };
                SetIdForForeignKeys(fKModel, DIManager.UnitOfWork, ref newOperation);


                return AddOperationToDB(newOperation);
            }
            return false;
        }

        protected override void GetModelsForOperationOptions<TObject, TModelForGet>(ref TObject modelParam, TModelForGet modelForGet)
        {
            AddOperationModel model = modelParam as AddOperationModel;
            ModelsForPersonalOperationModel operModel = modelForGet as ModelsForPersonalOperationModel;
            if (model != null && operModel != null)
            {
                operModel.CurrencyModel = _currencyManager.GetCurrencyWithCurrentName(model.Currency);
                operModel.CategoryModel = _categoryManager.GetCategoryWithCurrentName(model.Category,
    operModel.OperationType);
                operModel.SourceModel = _sourceManager.GetCategoryWithCurrentName(model.Source);
            }
        }

        /// <summary>
        /// Set ids for equal properties
        /// </summary>
        /// <param name="currencyModel"></param>
        /// <param name="categoryModel"></param>
        /// <param name="sourceModel"></param>
        /// <param name="modelForDb"></param>
        protected override void SetIdForForeignKeys<TObject, TModelForSet>( TModelForSet modelsForSet, IUnitOfWork unitOfWork, ref TObject operationParam){
            Operation operation = operationParam as Operation;
            PersonalAccountForeignKeyForSetModels fKModel = modelsForSet as PersonalAccountForeignKeyForSetModels;
            if (operation != null && fKModel != null)
            {
                if (fKModel.CurrencyModel != null)
                {
                    operation.CurrencyId = fKModel.CurrencyModel.Id;
                }
                if (fKModel.CategoryModel != null)
                {
                    operation.CategoryId = fKModel.CategoryModel.Id;
                }
                if (fKModel.SourceModel != null)
                {
                    operation.SourceId = fKModel.SourceModel.Id;
                }
                operation.UserId = unitOfWork.PersonalAccountantContext.Set<User>().FirstOrDefault(x => x.Name == fKModel.UserName).Id;

                operation.OperationTypeId = Convert.ToInt32(fKModel.OperationType);
            }

        }
    }
}
