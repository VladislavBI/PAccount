using BussinessLogic.ViewManagers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.Model;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.Model.Infrastructure.Abstract;
using PAccountant.DataLayer.Entity;
using PAccountant.BussinessLogic.Infrastructure.Abstract;

namespace BussinessLogic.ViewManagers.Concrete
{
    public class CurrencyManager : ICurrencyManager
    {
        IUnitOfWork _unitOfWork;
        IMapperHelper _mapperHelper;

        public CurrencyManager(IMapperHelper mapperHelperParam)
        {
            _mapperHelper = mapperHelperParam;
        }
        public CurrencyNameIdRateClass GetCurrencyWithCurrentName(string nameParam)
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                Currency contextCurrency = _unitOfWork.PersonalAccountantContext.Set<Currency>().FirstOrDefault(x => x.Name.ToUpper() == nameParam.ToUpper());
                return _mapperHelper.MapModel<Currency, CurrencyNameIdRateClass>(contextCurrency);
            }
        }

        public dynamic GetAllInList()
        {
            using (_unitOfWork = DIManager.UnitOfWork)
            {
                return _unitOfWork.PersonalAccountantContext.Set<Currency>().ToList();
            }
        }
    }
}
