using BussinessLogic.DBModelManagers.Abstract;
using BussinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.ViewManagers.Abstract
{
    public interface ICategoryManager
    {
        /// <summary>
        /// Returns entity that is equal to mentioned name(or create new one)
        /// </summary>
        /// <param name="Name">name to check</param>
        /// <returns>entity object</returns>
        NameIdClassModel GetCategoryWithCurrentName(string nameParam);

        /// <summary>
        /// Returns model that is equal to mentioned name(or create new one)
        /// </summary>
        /// <param name="Name">name to check</param>
        /// <param name="operationTypeParam">type of operation</param>
        /// <returns>entity object</returns>
        NameIdClassModel GetCategoryWithCurrentName(string nameParam, OperationType operationTypeParam);

        /// <summary>
        /// Get all operations in list according to operation type
        /// </summary>
        /// <param name="operationType">type of the operation
        /// <returns>list in dynamic</returns>
        dynamic GetAllInList(OperationType operationType);
        List<TotalFlowWithDateModel> GetMonthFlow();
    }
}
