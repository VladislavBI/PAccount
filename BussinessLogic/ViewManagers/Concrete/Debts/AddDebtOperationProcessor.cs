using BussinessLogic.ViewManagers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.DBModelManagers.Abstract;
using BussinessLogic.Model;
using PAccountant.Model.Infrastructure.Abstract;
using BussinessLogic.Infrastructure.Concrete;
using PAccountant.DataLayer.Entity;
using BussinessLogic.ViewManagers.Abstract.Debts;
using PAccountant.BussinessLogic.StaticClasses;

namespace BussinessLogic.ViewManagers.Concrete.Debts
{
    public class AddDebtOperationProcessor : AddOperationProcessorBase
    {
        ICurrencyManager _currencyManager;
        IAgentsManager _agentsManager;
        IUnitOfWork _unitOfWork;
        public AddDebtOperationProcessor(IDBManager dbManagerParam, ICurrencyManager currencyManagerParam, IAgentsManager agentsManagerParam) : base(dbManagerParam)
        {
            _currencyManager = currencyManagerParam;
            _agentsManager = agentsManagerParam;
        }

        public override bool addNewOperation<TObject>(TObject modelParam, string userName)
        {
            AddDebtModel model = modelParam as AddDebtModel;
            if (model != null && model != null && ValidationManager.modelIsValid(model))
            {
                DebtTypeEnum operationType = model.DebtType;

                ModelsForDebtOperationModel modelForOperation = new ModelsForDebtOperationModel
                {
                    AgentModel = new NameIdClassModel()
                };
                GetModelsForOperationOptions(ref model, modelForOperation);

                debt_DebtOperations newOperation = new debt_DebtOperations()
                {
                    StartDate=model.StartDate,
                    EndDate=model.EndDate,
                    StartSum = model.StartSum,
                    RewardSum = model.RewardSum,
                    Comment = model.Commentary,
                    CurrencyId = model.CurrencyId,
                    IsInProgress=true
                };
                DebtForeignKeyForSetModels fKModel = new DebtForeignKeyForSetModels
                {
                    AgentModel = modelForOperation.AgentModel,
                    UserName = userName,
                    DebtType = operationType
                };
                SetIdForForeignKeys(fKModel, DIManager.UnitOfWork, ref newOperation);


                return AddOperationToDB(newOperation);
            }
            return false;
        }

        public override bool AddOperationToDB<TOPerationModel>(TOPerationModel operationToAdd)
        {
            try
            {
                //if we have different types of  operationToAddand operation
                if (typeof(TOPerationModel) != typeof(debt_DebtOperations))
                {
                    _dbManager.CreateEntityFromModelForPersAccount<TOPerationModel, debt_DebtOperations>(operationToAdd);
                }
                else
                {
                    using (_unitOfWork = DIManager.UnitOfWork)
                    {
                        _unitOfWork.PersonalAccountantContext.Set<debt_DebtOperations>().Add(operationToAdd as debt_DebtOperations);
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

        protected override void GetModelsForOperationOptions<TObject, TModelForGet>(ref TObject modelParam, TModelForGet modelForGet)
        {
            AddDebtModel model = modelParam as AddDebtModel;
            ModelsForDebtOperationModel operModel = modelForGet as ModelsForDebtOperationModel;
            if (model != null && operModel != null)
            {
                operModel.AgentModel = _agentsManager.GetAgentWithCurrentName(model.AgentName);
            }
        }

        protected override void SetIdForForeignKeys<TObject, TModelForSet>(TModelForSet modelsForSet, IUnitOfWork unitOfWork, ref TObject operationParam)
        {
            debt_DebtOperations operation = operationParam as debt_DebtOperations;
            DebtForeignKeyForSetModels fKModel = modelsForSet as DebtForeignKeyForSetModels;
            if (operation != null && fKModel != null)
            {
                if (fKModel.AgentModel != null)
                {
                    operation.AgentId = fKModel.AgentModel.Id;
                }             
                operation.UserId = unitOfWork.PersonalAccountantContext.Set<User>().FirstOrDefault(x => x.Name == fKModel.UserName).Id;
                operation.DebtTypeId = Convert.ToInt32(fKModel.DebtType);
            }
        }
    }
}
