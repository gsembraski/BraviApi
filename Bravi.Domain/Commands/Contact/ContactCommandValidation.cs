using Bravi.Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Domain.Commands.Contact
{
    public class ContactCommandValidation : AbstractValidator<ContactCommand>
    {
        public ContactCommandValidation()
        {
            RuleFor(x => x.Value)
                .NotNull()
                .NotEmpty()
                .WithMessage("Error {PropertyName}: O campo é obrigatório.");

            RuleFor(x => x.Value)
                .EmailAddress()
                .When(x => x.Type == ContacTypeEnum.Mail)
                .WithMessage("Error {PropertyName}: O campo é obrigatório.");

            RuleFor(x => x.Value)
                .Matches("^[0-9]{2}-([0-9]{8}|[0-9]{9})")
                .When(x => x.Type == ContacTypeEnum.Phone)
                .WithMessage("Error {PropertyName}: O campo é obrigatório.");

            RuleFor(x => x.Type)
                .NotNull()
                .WithMessage("Error {PropertyName}: O campo é obrigatório.");

            RuleFor(x => x.Type)
                .IsInEnum()
                .WithMessage("Error {PropertyName}: O campo é obrigatório.");
        }
    }
}
