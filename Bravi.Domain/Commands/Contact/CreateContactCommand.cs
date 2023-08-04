using Bravi.Domain.Resources.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Domain.Commands.Contact
{
    public record CreateContactCommand : ContactCommand, IRequest<GenericCommandResult>
    {
        public CreateContactCommand SetIds(int personId) 
        {
            PersonId = personId;
            return this;
        }
    }
}
