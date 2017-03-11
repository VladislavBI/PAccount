using PAccountant.DataLayer.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAccountant.Model.Infrastructure.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext PersonalAccountantContext { get; }
        void Save();
        void Dispose(bool disposing);
    }

   
}

