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
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, GenericCommandResult>
    {
        private readonly IDomainNotificationContext _notification;
        private readonly IPersonRepository _personRepository;
        private readonly IContactRepository _contactRepository;

        public CreateContactCommandHandler(IDomainNotificationContext notification, 
            IPersonRepository personRepository, 
            IContactRepository contactRepository)
        {
            _notification = notification;
            _personRepository = personRepository;
            _contactRepository = contactRepository;
        }

        public async Task<GenericCommandResult> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetByIdAsync(request.PersonId);
            if (person == null)
            {
                _notification.NotifyError("Pessoa não cadastrada em nosso sistema.");
                return new GenericCommandResult(false);
            }

            var contact = await _contactRepository.GetAsync(x => x.Value == request.Value && x.PersonId == request.PersonId);
            if (contact != null)
            {
                _notification.NotifyError("Esse contato já esta vinculado a essa pessoa.");
                return new GenericCommandResult(false);
            }

            contact = new Entities.Contact(request.PersonId, request.Value, request.Type, request.IsMain);
            await _contactRepository.InsertAsync(contact);

            return new GenericCommandResult(true, "Contato cadastrado com sucesso!", person.Id);
        }
    }
}