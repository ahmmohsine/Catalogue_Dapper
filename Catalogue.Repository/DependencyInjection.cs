using Catalogue.Core.Interfeces;
using Catalogue.Infrastructure.Persistence;
using Catalogue.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalogue.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("La chaîne de connexion 'DefaultConnection' est introuvable ou vide.");
            }
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddSingleton<DbConnectionFactory>(_ => new DbConnectionFactory(connectionString));

            return services;
        }
    }
}
