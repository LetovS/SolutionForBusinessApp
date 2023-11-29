using Business.Abstract;
using Business.Abstract.Services;
using Business.Implementations.ChangeDetectors;
using Business.Implementations.Services;
using Business.Implementations.Validations;
using Business.Mapper;
using Business.Models.Order;
using Business.Models.OrderItem;
using Business.Models.Provider;
using Microsoft.Extensions.DependencyInjection;
using Store.Entities;

namespace Business.DI;

/// <summary>
/// Регистраия зависимостей бизнес логики
/// </summary>
public static class BusinessServiceCollections
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        // Регистрация автомаппера
        services.AddAutoMapper(typeof(BusinessMapperProfile));
        
        // Регистрация бизнес валидаторов
        services.AddScoped<IBusinessValidator<OrderItemRecord>,OrderItemValidator>();
        services.AddScoped<IBusinessValidator<OrderRecord>,OrderValidator>();
        services.AddScoped<IBusinessValidator<ProviderRecord>,ProviderValidator>();
        
        // Регистрация детекторов изменения
        services.AddScoped<IChangeDetector<OrderItemRecord, UpdateOrderItemModel>, OrderItemChangeDetector>();
        services.AddScoped<IChangeDetector<OrderRecord, UpdateOrderModel>, OrderChangeDetector>();
        services.AddScoped<IChangeDetector<ProviderRecord, UpdateProviderModel>, ProviderChangeDetector>();

        // Регистрация сервисов
        services.AddScoped<IBaseService<OrderItemRecord,CreateOrderItemModel,UpdateOrderItemModel>, OrderItemService>();
        services.AddScoped<IBaseService<OrderRecord,CreateOrderModel,UpdateOrderModel>, OrderService>();
        services.AddScoped<IBaseService<ProviderRecord,CreateProviderModel,UpdateProviderModel>, ProviderService>();
        
        return services;
    }
}