namespace Common.Enums;

/// <summary>
/// Тип ресурса
/// </summary>
public enum ResourceType
{
    /// <summary>
    /// Неизвестный тип ресурса
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Провайдер
    /// </summary>
    Provider = 1,

    /// <summary>
    /// Заказ
    /// </summary>
    Order = 2,
    
    /// <summary>
    /// Элемент заказа
    /// </summary>
    OrderItem = 3,
}
