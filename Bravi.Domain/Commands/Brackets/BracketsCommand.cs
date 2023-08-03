using Bravi.Domain.Resources.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Domain.Commands.Brackets
{
    public record BracketsCommand(string Text) : IRequest<GenericCommandResult>;
}
