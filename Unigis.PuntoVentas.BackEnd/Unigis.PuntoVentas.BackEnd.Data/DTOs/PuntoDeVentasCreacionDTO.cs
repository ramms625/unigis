using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Unigis.PuntoVentas.BackEnd.Data.Validaciones;

namespace Unigis.PuntoVentas.BackEnd.Data.DTOs
{
    public class PuntoDeVentasCreacionDTO
    {
        [DisplayName("descripción")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        public string Descripcion { get; set; }
        
        [DisplayName("latitud")]
        [Required(ErrorMessage = "La {0} es requerida.")]

        [Coordenas(false, "La latitud debe tener un valor válido (-90°/90°)")]
        public decimal Latitud { get; set; }
        
        [DisplayName("longitud")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        [Coordenas(false, "La longitud debe tener un valor válido (-180°/180°)")]
        public decimal Longitud { get; set; }
        
        [DisplayName("venta")]
        [Required(ErrorMessage = "El valor de la {0} es requerida.")]
        [NumeroPositivo(mensajeError: "La venta deben ser mayor a 0.")]
        public decimal Ventas { get; set; }

        [DisplayName("id zona")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        [NumeroPositivo("El id zona debe ser mayor a 0.")]
        public int IdZona { get; set; }
    }
}