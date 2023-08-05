using Bravi.Domain.Resources.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bravi.Domain.Commands.Contact
{
    public record UpdateContactCommand : ContactCommand, IRequest<GenericCommandResult>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public UpdateContactCommand SetId(int id) 
        {
            Id = id;
            return this;
        }
    }
}
