using eCommerce.Core.RepositoriesContracts;
using eCommerce.Infrastruture.DbContext;
using eCommerce.Infrastruture.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace eCommerce.Infrastruture;

    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add infrastructure services to dependency Injection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>

        public static IServiceCollection AddInfrastruture(this IServiceCollection services)
        {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<DapperDbContext>();
        // TO DO:Add service to IOC container
        //infrastructure services often include data access,caching and other low level components
        return services;
        }
    }

