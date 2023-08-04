using Bravi.Domain.Enums;
using Bravi.Domain.Resources.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Domain.Commands.Contact
{
    public record ContactCommand
    {
        public int PersonId { get; set; }
        public string Value { get; set; }
        public ContacTypeEnum Type { get; set; }
        public bool IsMain { get; set; }
    }
}
