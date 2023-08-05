using Bravi.Domain.Commands.Contact;
using Bravi.Domain.Resources.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bravi.Domain.Commands.Person
{
    public record DeletePersonCommand(int Id) : IRequest<GenericCommandResult>;
}
