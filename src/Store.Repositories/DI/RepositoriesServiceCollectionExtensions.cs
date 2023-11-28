using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Abstract;
using Store.Entities;
using Store.Migrations;
using Store.Repositories.Abstracts;
using Store.Repositories.Implementations;

namespace Store.Repositories.DI;

public static class RepositoriesServiceCollectionExtensions
{
    public static void AddDbContextAndRepositories(this IServiceCollection services, IConfiguration configurations)
    {
        services.AddDbContext<IResourceContext, ResourceContext>(options => 
            options.UseSqlServer(
                configurations.GetConnectionString("MsSql"),
                m => m.MigrationsAssembly(typeof(DbContextFactoryBase).Assembly.GetName().Name)));

        services.AddScoped<IDbReader, ResourceContext>();
        services.AddScoped<IDbUnitOfWork, ResourceContext>();
        services.AddScoped<IDbWriter, ResourceContext>();

        services.AddScoped<IEntityFactory, EntityFactory>();
        
        services.AddScoped(typeof(IBaseRepository<>), typeof(ProviderRepository));
        services.AddScoped(typeof(IBaseRepository<>), typeof(OrderItemRepository));
        services.AddScoped(typeof(IBaseRepository<>), typeof(OrderRepository));
    }
}