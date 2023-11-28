using Business.Abstract;
using Business.Models.Provider;
using Store.Entities;

namespace Business.Implementations.ChangeDetectors;

public class ProviderChangeDetector : IChangeDetector<ProviderRecord, UpdateProviderModel>
{
    public async Task<bool> HasNoChanges(ProviderRecord entity, UpdateProviderModel model, CancellationToken token)
    {
        var result = model.Name.Equals(entity.Name);
        return await Task.FromResult(result);
    }
}