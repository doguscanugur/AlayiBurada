using AlayıBurada.Bll;
using AlayıBurada.Dal.Concrete.EntityFramework.Repository;
using AlayıBurada.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AlayıBurada.MvcUI.App_Start
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel kernel;
        public NinjectControllerFactory()
        {
            kernel = new StandardKernel();
            AddBllBinds();
        }

        private void AddBllBinds()
        {
            this.kernel.Bind<IProductService>().To<ProductManager>().WithConstructorArgument("productRepository", new EfProductRepository());
            this.kernel.Bind<ICustomerService>().To<CustomerManager>().WithConstructorArgument("customerRepository", new EfCustomerRepository());
            this.kernel.Bind<ICategoryService>().To<CategoryManager>().WithConstructorArgument("categoryRepository", new EfCategoryRepository());
            this.kernel.Bind<IBasketService>().To<BasketManager>().WithConstructorArgument("basketRepository", new EfBasketRepository());
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)kernel.Get(controllerType);
        }
    }
}