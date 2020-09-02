using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GDev.WebApp.Extensions
{
    public class MoedaAtribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var moeda = Convert.ToDecimal(value, new CultureInfo("pt-BR"));
            } 
            catch (Exception)
            {
                return new ValidationResult("Moeda em formato inválido");
            }

            return base.IsValid(value, validationContext);
        }
    }
}
