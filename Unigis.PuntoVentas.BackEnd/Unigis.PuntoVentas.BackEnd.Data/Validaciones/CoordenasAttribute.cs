using System.ComponentModel.DataAnnotations;

namespace Unigis.PuntoVentas.BackEnd.Data.Validaciones
{
    public class CoordenasAttribute : ValidationAttribute
    {
        private readonly double _minValue;
        private readonly double _maxValue;
        private readonly string _mensajeError;
        public CoordenasAttribute(bool esLatitud, string mensajeError)
        {
            _mensajeError = mensajeError;

            if (esLatitud)
            {
                _minValue = -90;
                _maxValue = 90;
            }
            else
            {
                _minValue = -180;
                _maxValue = 180;
            }
        }


        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            if (!double.TryParse(value.ToString(), out double resultado))
                return new ValidationResult("No es un valor númerico");

            if (resultado >= _minValue && resultado <= _maxValue)
                return ValidationResult.Success;

            return new ValidationResult(_mensajeError);
        }
    }
}