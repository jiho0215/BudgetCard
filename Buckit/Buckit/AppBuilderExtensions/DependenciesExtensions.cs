using Microsoft.Extensions.DependencyInjection;
using Buckit.Data;

namespace Buckit.Web.AppBuilderExtensions
{
    public static class DependenciesExtensions
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<buckitdbContext>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IBucketRepository, BucketRepository>();
            services.AddScoped<IBucketTransactionRepository, BucketTransactionRepository>();
            services.AddScoped<IBuckitUserRepository, BuckitUserRepository>();
            return services;
        }
    }
}
