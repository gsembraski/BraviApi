using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Domain.Entities
{
    public class Person:Entity<int>
    {
        public Person() { }
        public Person(string name, string lastName, string nickName)
        {
            Name = name;
            LastName = lastName;
            NickName = nickName;
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string NickName { get; private set; }
    }
}
