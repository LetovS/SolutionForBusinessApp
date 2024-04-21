using Business.Models.Enums;

namespace Business.Abstract.Services;

public interface IBusinessService
{
    /// <summary>
    /// Тип ресурса
    /// </summary>
    ResourceType ResourceType { get; }
}