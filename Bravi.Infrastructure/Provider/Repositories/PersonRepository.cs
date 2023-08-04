using Bravi.Domain.Entities;
using Bravi.Domain.Repositories;
using Bravi.Infrastructure.Provider.Repositories.Base;
using Dapper;
using System;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;

namespace Bravi.Infrastructure.Provider.Repositories
{
    public class PersonRepository : RepositoryBase, IPersonRepository
    {
        public PersonRepository(IDbConnection dbContext) : base(dbContext)
        {
        }

        public Task<Person> GetAsync(Expression<Func<Person, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _dbContext.QueryFirstOrDefaultAsync<Person>("SELECT * FROM Person WHERE Id = @id", new { id });
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _dbContext.QueryAsync<Person>("SELECT * FROM Person");
        }

        public async Task InsertAsync(Person entity)
        {
            await _dbContext.ExecuteAsync("INSERT INTO Person (Name, LastName, Nickname) VALUES (@Name, @LastName, @Nickname)", entity);
        }

        public Task UpdateAsync(Person entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
