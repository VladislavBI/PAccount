using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.ViewManagers.Abstract
{
    public enum TemplatesType
    {
        PersAccount=1,
        Debts=2,
        Invest=3
    }
    public abstract class TemplateManagerBase
    {
        public abstract dynamic ReturnAddOpeartionTemplates();
    }
}
