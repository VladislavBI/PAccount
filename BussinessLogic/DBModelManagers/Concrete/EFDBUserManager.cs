using System;
using System.Collections.Generic;
using BussinessLogic.DBModelManagers.Abstract;
using PAccountant.BussinessLogic.Infrastructure.Abstract;
using PAccountant.BussinessLogic.StaticClasses;
using PAccountant.DataLayer.Entity;
using PAccountant.Model.Infrastructure.Abstract;

namespace BussinessLogic.DBModelManagers.Concrete
{
    public class EFDBUserManager: DBManager<User>
    {}
}
