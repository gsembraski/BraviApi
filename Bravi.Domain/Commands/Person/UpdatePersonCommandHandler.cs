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
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, GenericCommandResult>
    {
        private readonly IDomainNotificationContext _notification;
        private readonly IPersonRepository _personRepository;

        public UpdatePersonCommandHandler(IDomainNotificationContext notification, IPersonRepository personRepository)
        {
            _notification = notification;
            _personRepository = personRepository;
        }

        public async Task<GenericCommandResult> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetByIdAsync(request.Id);
            if (person == null)
            {
                _notification.NotifyError("Pessoa não cadastrada em nosso sistema.");
                return new GenericCommandResult(false);
            }

            person.Update(request.Name, request.LastName, request.Nickname);
            await _personRepository.UpdateAsync(person);

            return new GenericCommandResult(true, "Pessoa atualizada com sucesso!");
        }
    }
}