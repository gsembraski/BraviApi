using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Domain.Entities.Base
{
    public abstract class Entity<TId>
    {
        private TId _Id;

        public virtual TId Id
        {
            get
            {
                return _Id;
            }
            protected set
            {
                _Id = value;
            }
        }

        protected Entity()
        {
        }
    }
}
