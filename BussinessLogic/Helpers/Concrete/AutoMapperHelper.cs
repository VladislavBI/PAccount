using System;
using System.Collections.Generic;
using AutoMapper;
using PAccountant.BussinessLogic.Infrastructure.Abstract;

namespace PAccountant.BussinessLogic.Infrastructure.Concrete
{
    public class AutoMapperManager : IMapperHelper
    {
        public TTo MapModel<TFrom, TTo>(TFrom entity) where TTo : new()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TFrom, TTo>());
            return Mapper.Map<TFrom, TTo>(entity);
        }
        private static Object locker=new object();
        public List<TTo> MapListModel<TFrom, TTo>(List<TFrom> entity) where TTo : new()
        {
            lock (locker)
            {


                if (entity != null && entity.Count > 0)
                {
                    Mapper.Initialize(cfg => cfg.CreateMap<TFrom, TTo>());

                    return Mapper.Map<List<TFrom>, List<TTo>>(entity);
                }
                else
                {
                    return null;
                }
            }

        }

    }
}
