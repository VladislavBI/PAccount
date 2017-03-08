using BussinessLogic.Model;
using PAccountant.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.ViewManagers.Abstract
{
    public interface ICurrencyManager:IListGetter
    {
        CurrencyNameIdRateClass GetCurrencyWithCurrentName(string nameParam);

    }
}
