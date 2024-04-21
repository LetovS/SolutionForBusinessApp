using AutoMapper;
using Business.Abstract;
using Business.Abstract.Services;
using Business.Models.Order;
using Business.Models.OrderItem;
using Store.Abstract;
using Store.Entities;
using Store.Repositories.Abstracts;

namespace Business.Implementations.Services;

public class OrderItemService : BaseService<OrderItemRecord, CreateOrderItemModel, UpdateOrderItemModel>
{
    private readonly IEntityFactory _entityFactory;

    public OrderItemService(
        IDbReader reader,
        IDbWriter writer,
        IDbUnitOfWork unitOfWork,
        IBaseRepository<OrderItemRecord> repository,
        IBusinessValidator<OrderItemRecord> validator,
        IChangeDetector<OrderItemRecord, UpdateOrderItemModel> changeDetector,
        IMapper mapper,
        IEntityFactory entityFactory) : base(reader, writer, unitOfWork, repository, validator, changeDetector, mapper)
    {
        _entityFactory = entityFactory;
    }

    protected override OrderItemRecord GetNewEntity(int id, CreateOrderItemModel model)
    {
        return _entityFactory.NewOrderItem(id, model.OrderId, model.Name, model.Quantity, model.Unit);
    }
}