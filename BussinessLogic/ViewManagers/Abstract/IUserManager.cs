using BussinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.ViewManagers.Abstract
{
    public interface IUserManager
    {
        NameIdClassModel GetCategoryWithCurrentName(string nameParam);
        void CreateNewInstance(string nameParam);
    }
}
