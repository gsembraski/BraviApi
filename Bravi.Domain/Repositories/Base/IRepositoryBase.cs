using Bravi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Domain.Repositories.Base;

public interface IRepositoryBase<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : struct
{
    Task<TEntity> GetByIdAsync(TId id);
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
    Task InsertAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteByIdAsync(TId Id);
}
