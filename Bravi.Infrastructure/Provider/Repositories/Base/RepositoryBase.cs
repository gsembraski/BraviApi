using System.Data;

namespace Bravi.Infrastructure.Provider.Repositories.Base;

public abstract class RepositoryBase
{
    public readonly IDbConnection _dbContext;
    public RepositoryBase(IDbConnection dbContext)
    {
        _dbContext = dbContext;
    }
}
