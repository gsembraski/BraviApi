using Bravi.Domain.Entities;
using Bravi.Domain.Entities.Base;
using Bravi.Domain.Model;
using Bravi.Domain.Repositories;
using Bravi.Infrastructure.Provider.Repositories.Base;
using Dapper;
using Dommel;
using System;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;

namespace Bravi.Infrastructure.Provider.Repositories
{
    public class PersonRepository : RepositoryBase<Person, int>, IPersonRepository
    {
        public PersonRepository(IDbConnection dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Person>> GetAsync(Expression<Func<Person, bool>> predicate)
        {
            return await _dbContext.SelectAsync(predicate);
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _dbContext.QueryFirstOrDefaultAsync<Person>("SELECT * FROM Person WHERE Id = @id", new { id });
        }

        public async Task<PersonModel> GetAllByIdAsync(int id)
        {
            var gridReader = await _dbContext.QueryMultipleAsync(@"
                SELECT * FROM Person 
                    WHERE Id = @id;
                
                SELECT * FROM Contact
                    WHERE PersonId = @id;
            ", new { id });

            var result = new PersonModel();
            using (var mult = gridReader)
            {
                result = await mult.ReadFirstAsync<PersonModel>();
                result.Contacts = await mult.ReadAsync<Contact>();
            }

            return result;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _dbContext.QueryAsync<Person>("SELECT * FROM Person");
        }

        public async Task<int> InsertAsync(Person entity)
        {
            var id = await _dbContext.QueryFirstAsync<int>(@"
                INSERT INTO Person (Name, LastName, Nickname) VALUES (@Name, @LastName, @Nickname); 
                SELECT last_insert_rowid();", entity);
            return id;
        }

        public async Task UpdateAsync(Person entity)
        {
            await _dbContext.ExecuteAsync("UPDATE Person SET Name = @Name, LastName = @LastName, Nickname = @Nickname WHERE Id = @Id", entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _dbContext.ExecuteAsync("DELETE FROM Person WHERE Id = @id", new { id });
        }
    }
}
