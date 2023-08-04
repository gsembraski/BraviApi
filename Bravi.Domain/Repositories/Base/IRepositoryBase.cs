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
    Task<TEntity> GetByUniqueIdAsync(Guid uniqueId);
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

    Task<int> InsertAsync(TEntity entity);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteByIdAsync(TId Id);
    Task<bool> DeleteByUniqueIdAsync(Guid uniqueId);

    Task<IEnumerable<TEntity>> SelectAllAsync();
    Task<IEnumerable<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> predicate);
}
