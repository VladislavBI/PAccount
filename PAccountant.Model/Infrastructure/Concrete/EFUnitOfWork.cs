using PAccountant.DataLayer.Entity;
using PAccountant.Model.Infrastructure.Abstract;
using System;

namespace PAccountant.Model.Infrastructure.Concrete
{
    public class EFUnitOfWork : IUnitOfWork
    {
        PAccountantEntities context;
        private bool _disposed = false;
        IRepository _repository;
       
        IRepository IUnitOfWork.Repository
        {
            get
            {
                return _repository;
            }
        }

        public EFUnitOfWork()
        {
               context = new PAccountantEntities();
               _repository = new EFRepository(context);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
