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
                .When(x => (ContacTypeEnum)x.Type == ContacTypeEnum.Mail)
                .WithMessage("Error {PropertyName}: O e-mail esta no formato incorreto");

            RuleFor(x => x.Value)
                .Matches(@"^\(?\d{2}\)?[\s-]?[\s9]?\d{4}-?\d{4}$")
                .When(x => (ContacTypeEnum)x.Type == ContacTypeEnum.Phone)
                .WithMessage("Error {PropertyName}: O telefone esta no formato incorreto.");

            RuleFor(x => x.Type)
                .NotNull()
                .WithMessage("Error {PropertyName}: O campo é obrigatório.");
        }
    }
}
