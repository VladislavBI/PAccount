using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Infrastructure.Concrete
{
    public static class ReflectionManager
    {
        public static dynamic GetClassFromObject(object fromObjectParam)
        {
            Type objectType = fromObjectParam.GetType();
            return Activator.CreateInstance(objectType);
        }
        public static TEntity GetClassFromObject<TEntity>(object fromObjectParam)
        {
            var returnObject = GetClassFromObject(fromObjectParam);
            return (typeof(TEntity) == returnObject.GetType()) ? returnObject : null; 
        }

    }
}
