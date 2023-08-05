using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Domain.Commands.Person
{
    public class UpdatePersonCommandValidation : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidation()
        {
            RuleFor(x => x)
                .SetValidator(new PersonCommandValidation());
        }
    }
}
