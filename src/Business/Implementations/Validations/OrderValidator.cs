using Business.Abstract;
using Microsoft.EntityFrameworkCore;
using Store.Abstract;
using Store.Entities;
using Store.Repositories.Abstracts;

namespace Business.Implementations.Validations;

public class OrderValidator  : ValidatorBase<OrderRecord>
{
    private readonly IBaseRepository<OrderRecord> _repository;
    private readonly IDbReader _reader;

    public OrderValidator(IBaseRepository<OrderRecord> repository, IDbReader reader)
    {
        _repository = repository;
        _reader = reader;
    }
    
    public override async Task<bool> ValidateSave(OrderRecord entity, CancellationToken ct)
    {
        var entityDb = await _repository.GetByIdAsync(entity.Id, ct);
        // Если, найдена сущность и имена одинаковы с сохраняемой сущностью, это дубликат возвращаем False
        return !(entityDb != null && entityDb.Number == entity.Number);
    }

    /// <summary>
    /// Валидация удаления заказа
    /// </summary>
    /// <remarks>
    /// Если не найден заказ с указанным <see cref="entityId"/> считаем что уже удален
    /// Если у заказа имеются <see cref="OrderRecord.OrderItems"/> удалить нельзя
    /// </remarks>
    /// <param name="entityId">ИД удаляемой сущности</param>
    /// <param name="ct">токен</param>
    /// <returns>If True - can delete, else can't delete</returns>
    public override async Task<bool> ValidateDelete(int entityId, CancellationToken ct)
    {
        var entity = _repository.GetByIdAsync(entityId, ct);

        if (entity is null) return false;
        
        var orderIncludeOrderItems = await _reader.Read<OrderRecord>()
                                                .Include(x => x.OrderItems)
                                                .Where(x => x.Id == entityId)
                                                .ToListAsync(ct);
        if (orderIncludeOrderItems.Any())
        {
            return false;
        }
        
        return true;
    }
}