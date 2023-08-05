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
    public class QueryContactCommandHandler : IRequestHandler<QueryContactCommand, GenericCommandResult>
    {
        private readonly IDomainNotificationContext _notification;
        private readonly IPersonRepository _personRepository;
        private readonly IContactRepository _contactRepository;

        public QueryContactCommandHandler(IDomainNotificationContext notification, 
            IPersonRepository personRepository, 
            IContactRepository contactRepository)
        {
            _notification = notification;
            _personRepository = personRepository;
            _contactRepository = contactRepository;
        }

        public async Task<GenericCommandResult> Handle(QueryContactCommand request, CancellationToken cancellationToken)
        {
            var contacts = await _contactRepository.GetByPersonIdAsync(request.PersonId);

            return new GenericCommandResult(true, "Sucesso!", contacts);
        }
    }
}