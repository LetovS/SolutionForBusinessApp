using Business.Abstract.Models;

namespace Business.Models.Provider;

public sealed class UpdateProviderModel : IUpdateModel
{
    public UpdateProviderModel(string name)
    {
        Name = name;
    }
    /// <summary>
    /// Название провайдера
    /// </summary>
    public string Name { get; set; }
}