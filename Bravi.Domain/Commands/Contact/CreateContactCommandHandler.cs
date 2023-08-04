using Bravi.Domain.Resources.Notification;
using Bravi.Domain.Resources.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Domain.Commands.Contact
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, GenericCommandResult>
    {
        private readonly IDomainNotificationContext _notification;

        public CreateContactCommandHandler(IDomainNotificationContext notification)
        {
            _notification = notification;
        }

        public Task<GenericCommandResult> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {

            return default;
        }
    }
}