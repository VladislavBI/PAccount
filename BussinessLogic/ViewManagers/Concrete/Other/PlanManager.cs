using BussinessLogic.ViewManagers.Abstract.Investment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.Model;
using PAccountant.Model.Infrastructure.Abstract;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.DataLayer.Entity;

namespace BussinessLogic.ViewManagers.Concrete.Other
{
    public class PlanManager : PlanManagerBase
    {
        IUnitOfWork _unitOfWork;
        public override void AddPlan(AddPlanToStoreWithUser modelParam)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                var planUSDSum = scriptor.ChangeBuyRateForCurrency(modelParam.Sum, modelParam.CurrencyName, "USD");
                PAccountantEntities context = _unitOfWork.PersonalAccountantContext as PAccountantEntities;
                context.other_PlannedBuy.Add(new other_PlannedBuy()
                {
                    Name = modelParam.Name,
                    Sum = planUSDSum,
                    UserId = modelParam.UserId
                });
                _unitOfWork.Save();
            }
        }

        public override void AddSum(SumUserModel modelParam)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                PAccountantEntities context = _unitOfWork.PersonalAccountantContext as PAccountantEntities;
                var planUSDSum = scriptor.ChangeBuyRateForCurrency(modelParam.Sum, modelParam.CurrencyName, "USD");
                context.other_sumStored.Add(new other_sumStored()
                {
                    Sum = modelParam.Sum,
                    UserId = modelParam.UserId
                });
                _unitOfWork.Save();
            }
        }

        public override dynamic GetPlanes(int userIdParam)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                PAccountantEntities context = _unitOfWork.PersonalAccountantContext as PAccountantEntities;
                return context.other_PlannedBuy.Where(x => x.UserId == userIdParam).ToList();
            }
        }

        public override float GetStoredMoney(int userIdParam)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                PAccountantEntities context = _unitOfWork.PersonalAccountantContext as PAccountantEntities;
                var sumStoredModel = context.other_sumStored.FirstOrDefault(x => x.UserId == userIdParam)?.Sum;
                return sumStoredModel != null && sumStoredModel.HasValue ? 
                    Convert.ToSingle(sumStoredModel.Value) : 0;
            }
        }
    }
}
