using PAccountant.DataLayer.Entity;
using PAccountant.Model.Infrastructure.Abstract;
using System;
using System.Data.Entity.Validation;
using System.Data.Entity;

namespace PAccountant.Model.Infrastructure.Concrete
{
    public class EFUnitOfWork : IUnitOfWork
    {

        private DbContext _investmentContext;
        private DbContext _personalAccountantContext;
        private bool _disposed = false;

        public EFUnitOfWork()
        {
                _personalAccountantContext = new PAccountantEntities();
                _investmentContext = new PAccountantEntities();
        }

        
        public DbContext InvestmentContext
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DbContext PersonalAccountantContext
        {
            get
            {
                return _personalAccountantContext;
            }
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
                    try
                    {
                        _investmentContext.Dispose();
                    }
                    catch (Exception ex)
                    {
                       
                    }
                    try
                    {
                        _personalAccountantContext.Dispose();
                    }
                    catch (Exception ex)
                    {

                    }
                }
                this._disposed = true;
            }
        }

        public void Save()
        {
            try
            {
                _investmentContext.SaveChanges();
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
            try
            {
                _personalAccountantContext.SaveChanges();
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
