using System;
using BussinessLogic.DBModelManagers.Abstract;
using PAccountant.DataLayer.Entity;
using PAccountant.BussinessLogic.StaticClasses;
using BussinessLogic.Model;

namespace BussinessLogic.DBModelManagers.Concrete
{
    public class EFDBCurrencyManager : DBManager<Currency>
    {
        public override NameIdClassModel GetCategoryWithCurrentName(string nameParam)
        {
            using (_unitOfWork=DIManager.UnitOfWork)
            {
                Currency contextCurrency = _unitOfWork.Repository.FirstOrDefault<Currency>(x => x.Name.ToUpper() == nameParam.ToUpper());

                if (contextCurrency == null)
                {
                    int Id = 0;
                    contextCurrency = Int32.TryParse(nameParam, out Id) ?
                        _unitOfWork.Repository.FirstOrDefault<Currency>(x => x.Id == Id) :
                        CreateNewInstance(nameParam);
                }
                return _mapperManager.MapModel<Currency, CurrencyNameIdRateClass>(contextCurrency);
            }
        }

        private Currency CreateNewInstance(string nameParam)
        {
                _unitOfWork.Repository.Create(new Currency() { Name = nameParam });
                _unitOfWork.Save();
                return _unitOfWork.Repository.FirstOrDefault<Currency>(x => x.Name.ToUpper() == nameParam.ToUpper());
        }
    }

    public class CurrencyNameIdRateClass : NameIdClassModel
    {
        public double Buy_Rate { get; set; }
    }
}
