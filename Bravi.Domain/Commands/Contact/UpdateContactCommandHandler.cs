using Bravi.Domain.Enums;
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
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, GenericCommandResult>
    {
        private readonly IDomainNotificationContext _notification;
        private readonly IPersonRepository _personRepository;
        private readonly IContactRepository _contactRepository;

        public UpdateContactCommandHandler(IDomainNotificationContext notification, 
            IPersonRepository personRepository, 
            IContactRepository contactRepository)
        {
            _notification = notification;
            _personRepository = personRepository;
            _contactRepository = contactRepository;
        }

        public async Task<GenericCommandResult> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetByIdAsync(request.Id);
            if (contact == null)
            {
                _notification.NotifyError("Contato não cadastrado em nosso sistema.");
                return new GenericCommandResult(false);
            }

            contact.Update(request.Value, (ContacTypeEnum)request.Type, request.IsMain);
            await _contactRepository.UpdateAsync(contact);

            return new GenericCommandResult(true, "Contato atualizado com sucesso!", contact.Id);
        }
    }
}