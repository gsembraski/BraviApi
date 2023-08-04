using Bravi.Domain.Resources.Notification;
using Bravi.Domain.Resources.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Domain.Commands.Person
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, GenericCommandResult>
    {
        private readonly IDomainNotificationContext _notification;

        public CreatePersonCommandHandler(IDomainNotificationContext notification)
        {
            _notification = notification;
        }

        public Task<GenericCommandResult> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            return default;
        }
    }
}