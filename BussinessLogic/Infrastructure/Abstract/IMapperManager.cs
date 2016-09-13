using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAccountant.BussinessLogic.Infrastructure.Abstract
{
    public interface IMapperManager
    {
        TTo MapModel<TFrom, TTo>(TFrom entity) where TTo: new();

    }
}
