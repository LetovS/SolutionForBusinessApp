using Business.Abstract;
using Store.Entities;
using Store.Repositories.Abstracts;

namespace Business.Implementations.Validations;

public class OrderItemValidator : ValidatorBase<OrderItemRecord>
{
    private readonly IBaseRepository<OrderItemRecord> _repository;

    public OrderItemValidator(IBaseRepository<OrderItemRecord> repository)
    {
        _repository = repository;
    }

    public override async Task<bool> ValidateSave(OrderItemRecord entity, CancellationToken ct)
    {
        var entityDb = await _repository.GetByIdAsync(entity.Id, ct);
        // Если, найдена сущность и имена одинаковы с сохраняемой сущностью, это дубликат возвращаем False
        return !(entityDb != null && entityDb.Name == entity.Name);
    }
}