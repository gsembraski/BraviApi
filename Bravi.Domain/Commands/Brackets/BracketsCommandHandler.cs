using Bravi.Domain.Resources.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Domain.Commands.Brackets
{
    public class BracketsCommandHandler : IRequestHandler<BracketsCommand, GenericCommandResult>
    {
        public Task<GenericCommandResult> Handle(BracketsCommand request, CancellationToken cancellationToken)
        {
            var text = request.Text;
            while (text.Contains("()") || text.Contains("{}") || text.Contains("[]"))
            {
                text = text.Replace("()", "")
                    .Replace("{}", "")
                    .Replace("[]", "");
            }

            if (string.IsNullOrEmpty(text)) return Task.FromResult(new GenericCommandResult(true, "A sequencia esta correta.")) ;

            return Task.FromResult(new GenericCommandResult(false, "A Sequencia esta correta"));
        }
    }
}