using AutoMapper;
using Business.Abstract.Models;
using Store.Abstract;
using Store.Entities;
using Store.Entities.Base;
using Store.Entities.Base.Interfaces;
using Store.Repositories.Abstracts;

namespace Business.Abstract.Services;

public abstract class BaseService<TEntity, TCreateModel, TUpdateModel> : IBaseService<TEntity, TCreateModel, TUpdateModel>
    where TEntity : BaseEntity, IDbEntity, IEntityWithId
    where TCreateModel : ICreateModel
    where TUpdateModel : IUpdateModel
{
    protected readonly IDbReader Reader;
    protected readonly IDbWriter Writer;
    protected readonly IDbUnitOfWork UnitOfWork;
    protected readonly IBaseRepository<TEntity> Repository;
    protected readonly IBusinessValidator<TEntity> Validator;
    protected readonly IChangeDetector<TEntity, TUpdateModel> ChangeDetector;
    protected readonly IMapper Mapper;

    protected BaseService(
        IDbReader reader,
        IDbWriter writer,
        IDbUnitOfWork unitOfWork,
        IBaseRepository<TEntity> repository, 
        IBusinessValidator<TEntity> validator,
        IChangeDetector<TEntity, TUpdateModel> changeDetector,
        IMapper mapper
        )
    {
        Reader = reader;
        Writer = writer;
        UnitOfWork = unitOfWork;
        Repository = repository;
        Validator = validator;
        ChangeDetector = changeDetector;
        Mapper = mapper;
    }
    
    public async Task<TEntity> GetById(int id, CancellationToken ct)
    {
        return await Repository.GetByIdAsync(id, ct);
    }

    public async Task<int> CreateAsync(int id, TCreateModel createModel, CancellationToken ct)
    {
        var dbEntity = await Repository.GetByIdAsync(id, ct);
        
        if (dbEntity is not null)
        {
            
        }
        var entity = GetNewEntity(id, createModel);
        Mapper.Map(createModel, entity);
        await Validator.ValidateSave(entity, ct);
        Writer.Add(entity);
        await UnitOfWork.SaveChangesAsync(ct);
        return entity.Id;
        
        return dbEntity.Id;
    }

    public async Task<bool> UpdateAsync(int id, TUpdateModel updateModel, CancellationToken ct)
    {
        var entity = await Repository.GetByIdAsync(id, ct);
        if (entity is null) return false;

        if (await ChangeDetector.HasNoChanges(entity, updateModel, ct)) return false;

        Mapper.Map(updateModel, entity);
        Writer.Update(entity);
        await UnitOfWork.SaveChangesAsync(ct);
        
        return true;
    }

    public async Task<bool> DeleteByIdAsync(int id, CancellationToken ct)
    {
        var entity = await Repository.GetByIdAsync(id, ct);

        if (entity is null) return true;
        
        Writer.Delete(entity);
            
        var count = await UnitOfWork.SaveChangesAsync(ct);
        
        return count > 0 ? true : false;
    }

    public async Task<IReadOnlyList<TEntity>> GetAll(CancellationToken ct)
    {
        return await Repository.GetAllAsync(ct);
    }
    
    
    /// <summary>
    /// Создать новую сущность ресурса
    /// </summary>
    protected abstract TEntity GetNewEntity(int id, TCreateModel model);
}