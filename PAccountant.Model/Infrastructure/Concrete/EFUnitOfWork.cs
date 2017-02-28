using PAccountant.DataLayer.Entity;
using PAccountant.Model.Infrastructure.Abstract;
using System;
using System.Data.Entity.Validation;

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
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
