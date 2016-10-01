﻿using System;
using System.Collections.Generic;
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

        public List<TTo> MapListModel<TFrom, TTo>(List<TFrom> entity) where TTo : new()
        {
            if (entity!=null&&entity.Count>0)
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
