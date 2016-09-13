using AutoMapper;
using PAccountant.BussinessLogic.Infrastructure.Abstract;

namespace PAccountant.BussinessLogic.Infrastructure.Concrete
{
    public class AutoMapperManager : IMapperManager
    {
        public TTo MapModel<TFrom, TTo>(TFrom entity) where TTo: new()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TFrom, TTo>());
            return Mapper.Map< TFrom, TTo>(entity);
        }
    }
}
