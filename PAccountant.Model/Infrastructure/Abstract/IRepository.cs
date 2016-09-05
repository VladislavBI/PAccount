using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAccountant.Model.Infrastructure.Abstract
{
    public interface IRepository
    {
        IEnumerable<TEntity> GetALL<TEntity>() where TEntity : class;
        TModel GetItemModel<TEntity, TModel>(Func<TEntity, bool> expression) where TEntity : class;
        void Create<TEntity>(TEntity item) where TEntity : class; 
        void Update<TEntity>(TEntity item) where TEntity : class;
        void Delete<TEntity>(TEntity item) where TEntity : class;
    }

}
