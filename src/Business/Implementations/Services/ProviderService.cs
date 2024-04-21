using AutoMapper;
using Business.Abstract;
using Business.Abstract.Services;
using Business.Models.Order;
using Business.Models.Provider;
using Store.Abstract;
using Store.Entities;
using Store.Repositories.Abstracts;

namespace Business.Implementations.Services;

public class ProviderService : BaseService<ProviderRecord, CreateProviderModel, UpdateProviderModel>
{
    private readonly IEntityFactory _entityFactory;
    
    public ProviderService(
        IDbReader reader,
        IDbWriter writer,
        IDbUnitOfWork unitOfWork,
        IBaseRepository<ProviderRecord> repository,
        IBusinessValidator<ProviderRecord> validator,
        IChangeDetector<ProviderRecord, UpdateProviderModel> changeDetector,
        IMapper mapper,
        IEntityFactory entityFactory) : base(reader, writer, unitOfWork, repository, validator, changeDetector, mapper)
    {
        _entityFactory = entityFactory;
    }

    protected override ProviderRecord GetNewEntity(int id, CreateProviderModel model)
    {
        return _entityFactory.NewProvider(id, model.Name);
    }
}