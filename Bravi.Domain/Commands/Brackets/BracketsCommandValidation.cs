using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Domain.Commands.Brackets
{
    public class BracketsCommandValidation : AbstractValidator<BracketsCommand>
    {
        public BracketsCommandValidation()
        {
            RuleFor(x => x.Text)
                .NotNull()
                .NotEmpty()
                .WithMessage("Error {PropertyName}: O campo é obrigatório.");
        }
    }
}
