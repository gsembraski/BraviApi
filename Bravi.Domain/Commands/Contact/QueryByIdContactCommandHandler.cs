using Bravi.Domain.Repositories;
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
    public class QueryByIdContactCommandHandler : IRequestHandler<QueryByIdContactCommand, GenericCommandResult>
    {
        private readonly IDomainNotificationContext _notification;
        private readonly IContactRepository _contactRepository;

        public QueryByIdContactCommandHandler(IDomainNotificationContext notification, 
            IContactRepository contactRepository)
        {
            _notification = notification;
            _contactRepository = contactRepository;
        }

        public async Task<GenericCommandResult> Handle(QueryByIdContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetByIdAsync(request.Id);
            if (contact == null)
            {
                _notification.NotifyError("Contato não cadastrado em nosso sistema.");
                return new GenericCommandResult(false);
            }

            return new GenericCommandResult(true, "Sucesso!", contact);
        }
    }
}