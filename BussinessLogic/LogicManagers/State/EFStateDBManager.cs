using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic.DBModelManagers.Abstract;
using BussinessLogic.DBModelManagers.Concrete;
using PAccountant.DataLayer.Entity;

namespace BussinessLogic.LogicManagers.State
{
    public class EFStateDBManager : IDBStateManager
    {
        Dictionary<DbNames, IDBManager> _dbMangerList = new Dictionary<DbNames, IDBManager>();

        Dictionary<DbNames, IDBManager> IDBStateManager.DbMangerList
        {
            get
            {
                return _dbMangerList;
            }
        }

        public EFStateDBManager()
        {
            _dbMangerList.Add(DbNames.Category, new EFDBCategoryManager());
            _dbMangerList.Add(DbNames.Currency, new EFDBCurrencyManager());
            _dbMangerList.Add(DbNames.Source, new EFDBSourceManager());
            _dbMangerList.Add(DbNames.Operation, new EFDBOperationManager());
        }
    }
}
