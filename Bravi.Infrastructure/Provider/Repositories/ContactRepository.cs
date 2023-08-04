using Bravi.Domain.Entities;
using Bravi.Domain.Repositories;
using Bravi.Infrastructure.Provider.Repositories.Base;
using System.Data;
using System.Linq.Expressions;

namespace Bravi.Infrastructure.Provider.Repositories
{
    public class ContactRepository : RepositoryBase, IContactRepository
    {
        public ContactRepository(IDbConnection dbContext) : base(dbContext)
        {
        }

        public Task DeleteByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetAsync(Expression<Func<Contact, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(Contact entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Contact entity)
        {
            throw new NotImplementedException();
        }
    }
}
