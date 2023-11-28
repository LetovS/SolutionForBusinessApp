using Common.Enums;

namespace Business.Abstract;

/// <summary>
/// Маркерный интерфейс для сервисов бизнес-лоигики
/// </summary>
public interface IBusinessService
{
    /// <summary>
    /// Тип ресурса
    /// </summary>
    ResourceType ResourceType { get; }
}
