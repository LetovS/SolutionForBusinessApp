using Microsoft.Extensions.DependencyInjection;
using Store.Entities;
using Store.Repositories.Abstracts;
using Store.Repositories.Implementations;

namespace Store.Repositories.Extensions;

public static class ServiceExtension
{
    public static void AddRepositories(this IServiceCollection service)
    {
        service.AddScoped<IOrderRepository<OrderRecord>, OrderRepository<OrderRecord>>();
        service.AddScoped<IProviderRepository<ProviderRecord>, ProviderRepository<ProviderRecord>>();
        service.AddScoped<IOrderItemRepository<OrderItemRecord>, OrderItemRepository<OrderItemRecord>>();
    }
}