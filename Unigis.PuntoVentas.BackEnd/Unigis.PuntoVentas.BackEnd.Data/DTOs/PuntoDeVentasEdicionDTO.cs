using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Unigis.PuntoVentas.BackEnd.Data.DTOs
{
    public class PuntoDeVentasEdicionDTO
    {
        [DisplayName("id")]
        [Required(ErrorMessage = "El {0} es requerida.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe ser un número mayor a 0.")]
        public int Id { get; set; }

        [DisplayName("descripción")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        public string Descripcion { get; set; }

        [DisplayName("latitud")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        public decimal Latitud { get; set; }

        [DisplayName("longitud")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        public decimal Longitud { get; set; }

        [DisplayName("ventas")]
        [Required(ErrorMessage = "El valor de la {0} es requerida.")]
        public decimal Ventas { get; set; }

        [DisplayName("zona")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe ser un número mayor a 0.")]
        public int IdZona { get; set; }
    }
}