using PAccountant.Infrastructure.RatesUtil.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAccountant.Infrastructure.RatesUtil
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceService = SourceClassesFactory.Get(SourcesEnum.PrivatBank);
            var data = sourceService.GetCurrenciesRatesList();
        }
    }
}
