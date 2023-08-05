using Bravi.Domain.Entities;
using Bravi.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Domain.Repositories;

public interface IContactRepository : IRepositoryBase<Contact, int>
{
    Task DeleteByPersonIdAsync(int Id);
    Task<IEnumerable<Contact>> GetByPersonIdAsync(int id);
    Task<Contact> GetContactByValuePersonAsync(int personId, string value);
}
