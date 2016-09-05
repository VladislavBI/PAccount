using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAccountant.Model.Infrastructure.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository Repository { get;}
        void Save();
        void Dispose(bool disposing);
    }
}
