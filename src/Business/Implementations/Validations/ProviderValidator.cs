using Business.Abstract;
using Microsoft.EntityFrameworkCore;
using Store.Abstract;
using Store.Entities;
using Store.Repositories.Abstracts;

namespace Business.Implementations.Validations;

public class ProviderValidator : ValidatorBase<ProviderRecord>
{
    private readonly IBaseRepository<ProviderRecord> _repository;
    private readonly IDbReader _reader;

    public ProviderValidator(IBaseRepository<ProviderRecord> repository, IDbReader reader)
    {
        _repository = repository;
        _reader = reader;
    }
    
    public override async Task<bool> ValidateSave(ProviderRecord entity, CancellationToken ct)
    {
        var entityDb = await _repository.GetByIdAsync(entity.Id, ct);
        // Если, найдена сущность и имена одинаковы с сохраняемой сущностью, это дубликат возвращаем False
        return !(entityDb != null && entityDb.Name == entity.Name);
    }

    /// <summary>
    /// Валидация удаления провайдера
    /// </summary>
    /// <remarks>
    /// Если не найден провайдер с указанным <see cref="entityId"/> считаем что уже удален
    /// Если у провайдера имеются <see cref="ProviderRecord.Orders"/> удалить нельзя
    /// </remarks>
    /// <param name="entityId">ИД удаляемой сущности</param>
    /// <param name="ct">токен</param>
    /// <returns>If True - can delete, else can't delete</returns>
    public override async Task<bool> ValidateDelete(int entityId, CancellationToken ct)
    {
        var entity = _repository.GetByIdAsync(entityId, ct);

        if (entity is null) return false;
        
        var orderIncludeOrderItems = await _reader.Read<ProviderRecord>()
            .Include(x => x.Orders)
            .Where(x => x.Id == entityId)
            .ToListAsync(ct);
        
        if (orderIncludeOrderItems.Any())
        {
            return false;
        }
        
        return true;
    }
}