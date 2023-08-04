using Bravi.Domain.Resources.Notification;
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
        private readonly IDomainNotificationContext _notification;

        public BracketsCommandHandler(IDomainNotificationContext notification)
        {
            _notification = notification;
        }

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

            _notification.NotifyError("A Sequencia esta incorreta");
            return Task.FromResult(new GenericCommandResult(false));
        }
    }
}