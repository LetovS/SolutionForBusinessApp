using AutoMapper;
using Business.Abstract;
using Business.Abstract.Services;
using Business.Models.Order;
using Store.Abstract;
using Store.Entities;
using Store.Repositories.Abstracts;

namespace Business.Implementations.Services;

public class OrderService : BaseService<OrderRecord, CreateOrderModel, UpdateOrderModel>
{
    private readonly IEntityFactory _entityFactory;

    public OrderService(
        IDbReader reader,
        IDbWriter writer,
        IDbUnitOfWork unitOfWork,
        IBaseRepository<OrderRecord> repository,
        IBusinessValidator<OrderRecord> validator,
        IChangeDetector<OrderRecord, UpdateOrderModel> changeDetector,
        IMapper mapper,
        IEntityFactory entityFactory) : base(reader, writer, unitOfWork, repository, validator, changeDetector, mapper)
    {
        _entityFactory = entityFactory;
    }
    
    protected override OrderRecord GetNewEntity(int id, CreateOrderModel model)
    {
        return new OrderRecord(id, model.Number, model.Date, model.ProviderId);
    }
}