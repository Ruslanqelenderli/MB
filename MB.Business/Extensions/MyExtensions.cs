using MB.Business.Abstract.Services;
using MB.Business.Concrete.Managers;
using MB.DataAccess.Abstract;
using MB.DataAccess.Concrete.EntityFramework.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Extensions
{
    public static class MyExtensions
    {
        public static void ServiceCollectionMethod(this IServiceCollection service)
        {
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<IProductService, ProductManager>();
            service.AddScoped<ICategoryService, CategoryManager>();
            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<IRoleService, RoleManager>();
            service.AddScoped<IRoleRepository, RoleRepository>();
            service.AddScoped<IUserService, UserManager>();
            service.AddScoped<IUserRepository, UserRepository>();


        }
    }
}
