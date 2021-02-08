using InveonECommerce.Bussines.Abstract;
using InveonECommerce.Bussines.Concrete;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonECommerce.Bussines.DependencyResolver
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductRepository>().To<ProductRepository>().InSingletonScope();
            Bind<IUserRepository>().To<UserRepository>().InSingletonScope();

        }
    }
}
