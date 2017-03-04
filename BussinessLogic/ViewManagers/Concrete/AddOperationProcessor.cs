using BussinessLogic.DBModelManagers.Abstract;
using BussinessLogic.DBModelManagers.Concrete;
using BussinessLogic.Infrastructure.Concrete;
using BussinessLogic.LogicManagers.State;
using PAccountant.BussinessLogic.Infrastructure.Abstract;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.DataLayer.Entity;
using PAccountant.Model.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.ViewManagers.Concrete
{
    public class AddOperationProcessor
    {
        IDBStateManager _stateManager;
        IMapperManager _mapperManager;
        IUnitOfWork _unitOfWork;
        public AddOperationProcessor(IDBStateManager stateManager, IMapperManager mapperManager)
        {
            _stateManager = stateManager;
            _mapperManager = mapperManager;
        }

        public bool addNewOperation(AddOperationModel modelParam, string userName)
        {
            if (modelParam != null&&ValidationManager.modelIsValid(modelParam))
            {
                DBModelManagers.Abstract.OperationType operationType = modelParam.IsAddOperation ?
                    DBModelManagers.Abstract.OperationType.Income : DBModelManagers.Abstract.OperationType.Outcome;

                CurrencyNameIdRateClass currencyModel;
                NameIdClass categoryModel, sourceModel;
                GetModelsForOperationOptions(modelParam, operationType, out currencyModel, out categoryModel, out sourceModel);

                Operation newOperation = new Operation()
                {
                    Summ = Convert.ToDecimal(modelParam.Summ),
                    Date = modelParam.Date,
                    Commentary = modelParam.Commentary
                };
                SetIdForForeignKeys(currencyModel, categoryModel, sourceModel, userName, DIManager.UnitOfWork, operationType, ref newOperation);

                _stateManager.DbMangerList[DbNames.Operation].CreateEntityFromModel(newOperation);

                return true;
            }
            return false;
        }

        private void GetModelsForOperationOptions(AddOperationModel modelParam, DBModelManagers.Abstract.OperationType operationType, out CurrencyNameIdRateClass currencyModel, out NameIdClass categoryModel, out NameIdClass sourceModel)
        {
            currencyModel = _stateManager.DbMangerList[DbNames.Currency].GetCategoryWithCurrentName(modelParam.Currency) as CurrencyNameIdRateClass;
            categoryModel = _stateManager.DbMangerList[DbNames.Category].GetCategoryWithCurrentName(modelParam.Category,
operationType);
            sourceModel = _stateManager.DbMangerList[DbNames.Source].GetCategoryWithCurrentName(modelParam.Source);
        }

        /// <summary>
        /// Set ids for equal properties
        /// </summary>
        /// <param name="currencyModel"></param>
        /// <param name="categoryModel"></param>
        /// <param name="sourceModel"></param>
        /// <param name="modelForDb"></param>
        private static void SetIdForForeignKeys(
            CurrencyNameIdRateClass currencyModel, 
            NameIdClass categoryModel,
            NameIdClass sourceModel, 
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
            operation.UserId = unitOfWork.Repository.FirstOrDefault<User>(x=>x.Name== userName).Id;

            operation.OperationTypeId = Convert.ToInt32(operationType);
        }
    }
    public class AddOperationModel
    {
        public bool IsAddOperation { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Currency { get; set; }
        public double CurrencyRate { get; set; }
        [Required]
        [Range(0.0, double.MaxValue)]
        public double Summ { get; set; }
        public string Commentary { get; set; }

    };

}
