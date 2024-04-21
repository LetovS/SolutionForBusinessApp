using Business.Abstract.Models;

namespace Business.Models.Provider;

public sealed class CreateProviderModel : ICreateModel
{
    public CreateProviderModel(string name)
    {
        Name = name;
    }
    public string Name { get; set; }
}