using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Infrastructure.Concrete
{
    public static class ValidationManager
    {
        public static bool modelIsValid(object model)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model);
            if (!Validator.TryValidateObject(model, context, results, true))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
