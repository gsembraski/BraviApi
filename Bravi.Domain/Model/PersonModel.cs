using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bravi.Domain.Model
{
    public class PersonModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }

        [JsonIgnore]
        public IEnumerable<ContactModel> Contacts { get; set; }
        public IEnumerable<ContactModel> EmailContacts { get { return Contacts.Where(x => x.Type == Enums.ContacTypeEnum.Mail); } }
        public IEnumerable<ContactModel> PhoneContacts { get { return Contacts.Where(x => x.Type == Enums.ContacTypeEnum.Phone); } }
    }
}
