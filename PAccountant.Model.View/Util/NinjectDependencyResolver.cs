using BussinessLogic.DBModelManagers.Abstract;
using BussinessLogic.Model;
using BussinessLogic.ViewManagers.Abstract;
using BussinessLogic.ViewManagers.Abstract.Debts;
using BussinessLogic.ViewManagers.Concrete;
using BussinessLogic.ViewManagers.Concrete.Debts;
using BussinessLogic.ViewManagers.Concrete.PersonalAccountant;
using Ninject;
using PAccountant.BussinessLogic.Infrastructure.Abstract;
using PAccountant.BussinessLogic.Infrastructure.Concrete;
using PAccountant.DataLayer.Entity;
using PAccountant.Model.Infrastructure.Abstract;
using PAccountant.Model.Infrastructure.Concrete;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PAccountant.Model.View.Util
{
    public class NinjectDependencyResolver:IDependencyResolver
    {
        IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IUnitOfWork>().To<EFUnitOfWork>();
            kernel.Bind<IMapperHelper>().To<AutoMapperManager>();
            kernel.Bind(typeof(AddOperationProcessorBase)).To<PersAccounantAddOperationProcessor>();
            kernel.Bind<ISourceManager>().To<PersAccountSourceManager>();
            kernel.Bind<ICategoryManager>().To<PersAccountCategoryManager>();
            kernel.Bind<ICurrencyManager>().To<CurrencyManager>();
            kernel.Bind<ExtremumsManagerBase>().To<PersAccountExtremumsManager>();
            kernel.Bind<StatisticManagerBase>().To<PersAccountStatisticManager>();
            kernel.Bind<IOperationManager>().To<OperationManager>();
            kernel.Bind(typeof(IDBManager)).To<EFDBManager>();
            kernel.Bind(typeof(TemplateManagerBase)).To<PersAccTemplateManager>();

            

            kernel.Bind(typeof(IAgentsManager)).To<AgentsManager>();

        }
    }
}