using Bravi.Domain.Entities.Base;
using Bravi.Domain.Repositories.Base;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;

namespace Bravi.Infrastructure.Provider.Repositories.Base;

public abstract class RepositoryBase<TEntity, TId>
    where TEntity : Entity<TId> 
    where TId : struct 
{
    protected readonly IDbConnection _dbContext;
    public RepositoryBase(IDbConnection dbContext)
    {
        _dbContext = dbContext;
    }
}
