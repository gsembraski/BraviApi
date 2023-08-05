using Bravi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Domain.Model
{
    public class ContactModel
    {
        public string Value { get; set; }
        public ContacTypeEnum Type { get; set; }
        public bool IsMain { get; set; }
    }
}
