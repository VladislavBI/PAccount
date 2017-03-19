using BussinessLogic.Model;
using BussinessLogic.ViewManagers.Abstract;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.DataLayer.Entity;
using PAccountant.Model.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.ViewManagers.Concrete.PersonalAccountant
{
    public class PersAccTemplateManager : TemplateManagerBase
    {
        IUnitOfWork _unitOfWork;
        public override dynamic ReturnAddOpeartionTemplates()
        {
            using (_unitOfWork=DIManager.UnitOfWork)
            {
                return _unitOfWork.PersonalAccountantContext.Set<template_Operations>().Select(x => new PersAccTemplateModel
                {
                    Id=x.Id,
                    Name=x.Name,
                    CategoryId=x.Operation.CategoryId,
                    CurrencyId=x.Operation.CurrencyId,
                    Commentary=x.Operation.Commentary,
                    Date=x.Operation.Date,
                    SourceId=x.Operation.SourceId,
                    SumDecimal=x.Operation.Summ
                }).ToList();
            }        
        }
    }
}
