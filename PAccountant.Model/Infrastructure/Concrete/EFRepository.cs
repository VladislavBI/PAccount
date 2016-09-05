using PAccountant.Model.Entity;
using PAccountant.Model.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

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

        public IEnumerable<TEntity> GetALL<TEntity>() where TEntity : class
        {
            return db.Set<TEntity>();
        }

        public TModel GetItemModel<TEntity, TModel>(Func<TEntity, bool> expression) where TEntity : class
        {
            TEntity entity = GetALL<TEntity>().FirstOrDefault(x => expression(x));
            Mapper.Initialize(cfg => cfg.CreateMap<TEntity, TModel>());
            var model = Mapper.Map<TEntity, TModel>(entity);
            return model;
        }

        public void Create<TEntity>(TEntity item) where TEntity:class
        {
            db.Set<TEntity>().Add(item);
        }

        public void Update<TEntity>(TEntity item) where TEntity : class
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
