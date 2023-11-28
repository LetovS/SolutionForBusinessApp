using Store.Entities;

namespace Store.Repositories.Abstracts;

/// <summary>
/// Фабрика сущностей БД Ресурсов
/// </summary>
/// <remarks>Только создает сущности, не сохраняет их в БД</remarks>
public interface IEntityFactory
{
    /// <summary>
    /// Создать новый элемент заказа
    /// </summary>
    OrderItemRecord NewOrderItem(int id, int orderId, string name, decimal quantity, string unit);
    
    /// <summary>
    /// Создать новый заказ
    /// </summary>
    OrderRecord NewOrder(int id, string number, DateTime date, int providerId);
    
    /// <summary>
    /// Создать нового провайдера
    /// </summary>
    ProviderRecord NewProvider(int id, string name);
}