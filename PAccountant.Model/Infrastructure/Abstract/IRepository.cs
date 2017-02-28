using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PAccountant.Model.Infrastructure.Abstract
{
    public interface IRepository
    {
        List<TEntity> GetALL<TEntity>() where TEntity : class;
        TEntity FirstOrDefault<TEntity>(Func<TEntity, bool> expression) where TEntity : class;
        bool AnyItemMeetingDemands<TEntity>(Predicate<TEntity> expression) where TEntity : class;
        void Create<TEntity>(TEntity item) where TEntity : class; 
        void Update<TEntity>(TEntity item) where TEntity : class;
        void Delete<TEntity>(TEntity item) where TEntity : class;
        List<TEntity> Where<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class;

    }

}
