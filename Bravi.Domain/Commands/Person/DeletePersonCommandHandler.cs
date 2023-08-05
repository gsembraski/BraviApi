using Bravi.Domain.Repositories;
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
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, GenericCommandResult>
    {
        private readonly IDomainNotificationContext _notification;
        private readonly IPersonRepository _personRepository;
        private readonly IContactRepository _contactRepository;

        public DeletePersonCommandHandler(IDomainNotificationContext notification, IPersonRepository personRepository, IContactRepository contactRepository)
        {
            _notification = notification;
            _personRepository = personRepository;
            _contactRepository = contactRepository;
        }

        public async Task<GenericCommandResult> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetByIdAsync(request.Id);
            if (person == null)
            {
                _notification.NotifyError("Pessoa não cadastrada em nosso sistema.");
                return new GenericCommandResult(false);
            }
            await _contactRepository.DeleteByPersonIdAsync(person.Id);
            await _personRepository.DeleteByIdAsync(person.Id);

            return new GenericCommandResult(true, "Pessoa removida com sucesso!");
        }
    }
}