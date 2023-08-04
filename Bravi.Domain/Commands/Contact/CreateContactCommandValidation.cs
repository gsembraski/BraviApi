using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Domain.Commands.Contact
{
    public class CreateContactCommandValidation : AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidation()
        {
            RuleFor(x => x).SetValidator(new ContactCommandValidation());
        }
    }
}
