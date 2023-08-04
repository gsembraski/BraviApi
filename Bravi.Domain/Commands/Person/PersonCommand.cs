using Bravi.Domain.Commands.Contact;
using Bravi.Domain.Resources.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Domain.Commands.Person
{
    public record PersonCommand
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
    }
}
