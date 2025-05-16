using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Unigis.PuntoVentas.BackEnd.Data.Models;

namespace Unigis.PuntoVentas.BackEnd.Data.Entidades
{
    public class Zonas : IId
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Descripcion { get; set; }
    }
}