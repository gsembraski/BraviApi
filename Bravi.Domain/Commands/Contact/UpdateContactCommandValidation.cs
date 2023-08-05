using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Domain.Commands.Contact
{
    public class UpdateContactCommandValidation : AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactCommandValidation()
        {
            RuleFor(x => x).SetValidator(new ContactCommandValidation());
        }
    }
}
