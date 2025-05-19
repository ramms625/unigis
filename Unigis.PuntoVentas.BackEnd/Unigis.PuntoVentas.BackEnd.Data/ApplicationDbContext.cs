using Microsoft.EntityFrameworkCore;
using Unigis.PuntoVentas.BackEnd.Data.Entidades;

namespace Unigis.PuntoVentas.BackEnd.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
            
        }

        public DbSet<PuntoDeVentas> PuntoVentas { get; set; }
        public DbSet<Zonas> Zonas { get; set; }
    }
}