using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDev.Business.Model.Validations
{
    public class ModuloValidation : AbstractValidator<Modulo>
    {
        public ModuloValidation()
        {
            RuleFor(m => m.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio.")
                .Length(2, 100).WithMessage("O campo {PropetyName} tem que ter no mínimo {MinLength} e no máximo {MaxLength}");
        }
    }
}
