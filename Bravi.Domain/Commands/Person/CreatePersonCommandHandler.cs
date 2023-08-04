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
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, GenericCommandResult>
    {
        private readonly IDomainNotificationContext _notification;
        private readonly IPersonRepository _personRepository;

        public CreatePersonCommandHandler(IDomainNotificationContext notification, IPersonRepository personRepository)
        {
            _notification = notification;
            _personRepository = personRepository;
        }

        public async Task<GenericCommandResult> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Entities.Person(request.Name, request.LastName, request.Nickname);
            await _personRepository.InsertAsync(person);

            return new GenericCommandResult(true, "Pessoa cadastrada com sucesso!", person.Id);
        }
    }
}