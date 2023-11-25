﻿using CorePersistence.EntityBaseModel;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace CorePersistence.Repositories;

public interface IEntityRepository<TEntity, TId> where TEntity : Entity<TId>

{
    void Add(TEntity entity);
    TEntity? GetById(TId Id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
    TEntity? GetByFilter(Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null
        );
    void Delete(TEntity entity);
    void Update(TEntity entity);
    List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
}
