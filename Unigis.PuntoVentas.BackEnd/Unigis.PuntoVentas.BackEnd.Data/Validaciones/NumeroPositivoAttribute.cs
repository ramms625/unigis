using System.ComponentModel.DataAnnotations;

namespace Unigis.PuntoVentas.BackEnd.Data.Validaciones
{
    public class NumeroPositivoAttribute : ValidationAttribute
    {
        private readonly string _mensajeError;
        public NumeroPositivoAttribute(string mensajeError)
        {
            _mensajeError = mensajeError;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            if (!double.TryParse(value.ToString(), out double resultado))
                return new ValidationResult("No es un valor númerico");

            if (resultado <= 0)
                return new ValidationResult(_mensajeError);

            return ValidationResult.Success;
        }
    }
}