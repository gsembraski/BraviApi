using Bravi.Domain.Entities.Base;
using Bravi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Domain.Entities
{
    public class Contact : Entity<int>
    {
        public Contact() { }
        public Contact(int personId, string value, ContacTypeEnum type, bool isMain)
        {
            PersonId = personId;
            Value = value;
            Type = type;
            IsMain = isMain;
        }

        public int PersonId { get; private set; }
        public string Value { get; private set; }
        public ContacTypeEnum Type { get; private set; }
        public bool IsMain { get; private set; }


        public void Update(string value, ContacTypeEnum type, bool isMain)
        {
            Value = value;
            Type = type;
            IsMain = isMain;
        }
    }
}
