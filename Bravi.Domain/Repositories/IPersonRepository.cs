using Bravi.Domain.Entities;
using Bravi.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Domain.Repositories;

public interface IPersonRepository : IRepositoryBase<Person, int> {
    public Task<IEnumerable<Person>> GetAllAsync();
}
