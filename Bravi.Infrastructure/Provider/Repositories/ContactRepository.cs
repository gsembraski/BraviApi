using Bravi.Domain.Entities;
using Bravi.Domain.Repositories;
using Bravi.Infrastructure.Provider.Repositories.Base;
using Dapper;
using Dommel;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;

namespace Bravi.Infrastructure.Provider.Repositories;

public class ContactRepository : RepositoryBase<Contact, int>, IContactRepository
{
    public ContactRepository(IDbConnection dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Contact>> GetByPersonIdAsync(int id)
    {
        return await _dbContext.QueryAsync<Contact>("SELECT * FROM Contact WHERE PersonId = @id", new { id });
    }

    public async Task<Contact> GetByIdAsync(int id)
    {
        return await _dbContext.QueryFirstOrDefaultAsync<Contact>("SELECT * FROM Contact WHERE Id = @id", new { id });
    }

    public async Task<int> InsertAsync(Contact entity)
    {
       return await _dbContext.ExecuteAsync(@"
                INSERT INTO Contact(Value, Type, PersonId, IsMain) Values (@Value, @Type, @PersonId, @IsMain);
                UPDATE Contact SET IsMain = 0 WHERE PersonId = @PersonId AND Id <> last_insert_rowid() AND IsMain = @IsMain AND Type = @Type;
            ", entity);
    }

    public async Task UpdateAsync(Contact entity)
    {
        await _dbContext.ExecuteAsync(@"
                UPDATE Contact SET Value = @Value, Type = @Type, IsMain = @IsMain WHERE Id = @Id;
                UPDATE Contact SET IsMain = 0 WHERE PersonId = @PersonId AND Id <> @Id AND 1 = @IsMain AND Type = @Type;
            ", entity);
    }

    public async Task DeleteByIdAsync(int id)
    {
        await _dbContext.ExecuteAsync("DELETE FROM Contact WHERE Id = @id", new { id });
    }

    public async Task DeleteByPersonIdAsync(int id)
    {
        await _dbContext.ExecuteAsync("DELETE FROM Contact WHERE PersonId = @id", new { id });
    }

    public async Task<Contact> GetContactByValuePersonAsync(int personId, string value)
    {
        return await _dbContext.QueryFirstOrDefaultAsync<Contact>("SELECT * FROM Contact WHERE PersonId = @personId AND Value = @value", new { personId, value});
    }

    public Task<IEnumerable<Contact>> GetAsync(Expression<Func<Contact, bool>> predicate)
    {
        throw new NotImplementedException();
    }
}
