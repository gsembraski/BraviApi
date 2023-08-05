using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bravi.Domain.Entities.Base;

namespace Bravi.Domain.Entities
{
    public class Person:Entity<int>
    {
        public Person() { }
        public Person(string name, string lastName, string nickname)
        {
            Name = name;
            LastName = lastName;
            Nickname = nickname;
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Nickname { get; private set; }

        public void Update(string name, string lastName, string nickname)
        {
            Name = name;
            LastName = lastName;
            Nickname = nickname;
        }
    }
}
