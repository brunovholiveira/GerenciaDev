using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDev.Business.Model.Validations
{
    public class AcessoValidation : AbstractValidator<Acesso>
    {
        public AcessoValidation()
        {
            RuleFor(a => a.Cliente)
                .NotNull().WithMessage("Cliente não informado.");

            RuleFor(a => a.Modulo)
                .NotNull().WithMessage("Módulo não informado");    
        }
    }
}
