using BussinessLogic.DBModelManagers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.LogicManagers.State
{
    public enum DbNames
    {
        Category,
        Currency,
        Source,
        User,
        Operation
    }
    /// <summary>
    /// Inherit state method for choose from different db managers
    /// </summary>
    public interface IDBStateManager
    {
        Dictionary<DbNames, IDBManager> DbMangerList { get; }
    }
}
