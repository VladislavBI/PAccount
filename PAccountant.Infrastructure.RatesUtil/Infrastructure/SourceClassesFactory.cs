using PAccountant.Infrastructure.RatesUtil.Helpers;

namespace PAccountant.Infrastructure.RatesUtil.Infrastructure
{
    public class SourceClassesFactory
    {
        public static IRatesDataGetter Get(SourcesEnum source)
        {
            
            switch (source)
            {
                case SourcesEnum.PrivatBank:
                    return new PBRatesDataGetter();
                default:
                    return null;
            }
        }
    }
}
