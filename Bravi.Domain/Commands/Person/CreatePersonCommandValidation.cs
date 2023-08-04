using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Domain.Commands.Person
{
    public class CreatePersonCommandValidation : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidation()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Error {PropertyName}: O campo é obrigatório.");

            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Error {PropertyName}: O campo é obrigatório.");

            RuleFor(x => x.NickName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Error {PropertyName}: O campo é obrigatório.");


            RuleFor(x => x.NickName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Error {PropertyName}: O campo é obrigatório.");
        }
    }
}
