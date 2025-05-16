using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Unigis.PuntoVentas.BackEnd.Data.Models;

namespace Unigis.PuntoVentas.BackEnd.Data.Entidades
{
    //PuntoVentas interfiere con el namespace
    [Table("PuntoVentas")]
    public class PuntoDeVentas : IId
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Descripcion { get; set; }

        [Column(TypeName = "decimal(10, 7)")]
        public decimal Latitud { get; set; }

        [Column(TypeName = "decimal(10, 7)")]
        public decimal Longitud { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Ventas { get; set; }

        public int IdZona { get; set; }

        [ForeignKey(nameof(IdZona))]
        public Zonas Zona { get; set; }
    }
}