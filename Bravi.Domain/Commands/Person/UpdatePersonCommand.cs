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
    public record UpdatePersonCommand : PersonCommand, IRequest<GenericCommandResult>
    {
        [JsonIgnore]
        public int Id { get; set; }
    
        public UpdatePersonCommand SetId(int id)
        {
            Id = id;
            return this;
        }
    }
}
