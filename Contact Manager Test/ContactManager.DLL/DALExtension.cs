using ContactManager.DLL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ContactManager.DLL
{
    public static class DALExtension
    {
        public static IServiceCollection ConfigureDAL(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}