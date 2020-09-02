using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDev.Business.Model.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(c => c.RazaoSocial)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa se fornecido.")
                .Length(2, 100).WithName("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");                
        }
    }
}
