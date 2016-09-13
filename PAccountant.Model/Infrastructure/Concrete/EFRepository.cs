using PAccountant.Model.Infrastructure.Abstract;
using System;
using System.Data.Entity;
using System.Linq;
using PAccountant.DataLayer.Entity;
using System.Collections.Generic;

namespace PAccountant.Model.Infrastructure.Concrete
{
    class EFRepository : IRepository
    {
        private PAccountantEntities db;
        public EFRepository(PAccountantEntities context)
        {
            db = context;
        }
        public void Delete<TEntity>(TEntity item) where TEntity : class
        {
            db.Entry(item).State = EntityState.Deleted;
        }

        public List<TEntity> GetALL<TEntity>() where TEntity : class
        {
            return db.Set<TEntity>().ToList();
        }

        public TEntity GetItemModel<TEntity>(Func<TEntity, bool> expression) where TEntity : class
        {
            return GetALL<TEntity>().FirstOrDefault(x=>expression(x));
        }

        public void Create<TEntity>(TEntity item) where TEntity:class
        {
            db.Set<TEntity>().Add(item);
        }

        public void Update<TEntity>(TEntity item) where TEntity : class
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public bool AnyItemMeetingDemands<TEntity>(Predicate<TEntity> expression) where TEntity : class
        {
            return GetALL<TEntity>().Any(x=>expression(x));
        }
    }
}
