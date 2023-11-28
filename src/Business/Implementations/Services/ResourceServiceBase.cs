using AutoMapper;
using Business.Abstract;
using Common.Enums;
using Store.Entities.Base;
using Store.Entities.Base.Interfaces;
using Store.Repositories.Abstracts;

namespace Business.Implementations.Services;

internal abstract class ResourceServiceBase<TEntity, TCreateModel, TUpdateModel> : IBusinessService
    where TEntity: BaseEntity, IDbEntity, IEntityWithId
    where TCreateModel : class
    where TUpdateModel : class
{
    protected readonly IBaseRepository<TEntity> Repository;
    protected readonly IBusinessValidator<TEntity> Validator;
    protected readonly IChangeDetector<TEntity, TUpdateModel> ChangeDetector;
    protected readonly IMapper Mapper;
    
    public abstract ResourceType ResourceType { get; }

    protected ResourceServiceBase(
        IBaseRepository<TEntity> repository,
        IBusinessValidator<TEntity> validator,
        IChangeDetector<TEntity, TUpdateModel> changeDetector,
        IMapper mapper)
    {
        Repository = repository;
        Validator = validator;
        ChangeDetector = changeDetector;
        Mapper = mapper;
    }
    
    public virtual async Task<int> Create(int id, TCreateModel model, CancellationToken token)
    {
        var dbEntity = await Repository.GetByIdAsync(id, token);
        TEntity entity = null;
        if (dbEntity is null)
        {
            entity = GetNewEntity(id, model);
            Mapper.Map(model, entity);
            await Validator.ValidateSave(entity, token);
            await Repository.CreateAsync(entity, token);
        }

        return entity.Id;
    }
    
    
    /// <summary>
    /// Создать новую сущность ресурса
    /// </summary>
    protected abstract TEntity GetNewEntity(int id, TCreateModel model);
    
    
}