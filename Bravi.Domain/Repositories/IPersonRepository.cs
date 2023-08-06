using Bravi.Domain.Entities;
using Bravi.Domain.Model;
using Bravi.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Domain.Repositories;

public interface IPersonRepository : IRepositoryBase<Person, int> {
    Task<IEnumerable<Person>> GetAllAsync();
    Task<PersonModel> GetAllByIdAsync(int id);
}
