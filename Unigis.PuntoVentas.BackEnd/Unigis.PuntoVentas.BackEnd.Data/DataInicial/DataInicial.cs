using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Unigis.PuntoVentas.BackEnd.Data.Entidades;

namespace Unigis.PuntoVentas.BackEnd.Data.DataInicial
{
    public class DataInicial : IDataInicial
    {
        private readonly ILogger<DataInicial> _logger;
        private readonly ApplicationDbContext _context;
        public DataInicial(
            ILogger<DataInicial> logger,
            ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }



        
        public async Task InsercionDatos()
        {
            await AddMigraciones();
            await AddDataZona();
        }


        private async Task AddMigraciones()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                    await _context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error de migración: {ex.Message}");
            }
        }


        private async Task AddDataZona()
        {
            var zonas = new List<Zonas>
            {
                new () { Descripcion = "Zona centro"},
                new () { Descripcion = "Zona norte"},
                new () { Descripcion = "Zona sur"},
                new () { Descripcion = "Zona este"},
                new () { Descripcion = "Zona oeste"},
            };

            foreach (var zona in zonas)
            {
                if (!await _context.Zonas.AnyAsync(x => x.Descripcion == zona.Descripcion))
                {
                    _context.Zonas.Add(zona);
                    await _context.SaveChangesAsync();
                }
            }
        }


        private async Task AddPuntoVentasIniciales()
        {
            var ventas = new List<PuntoDeVentas>
            {

            };


            foreach (var venta in ventas)
            {
                if (!await _context.PuntoVentas.AnyAsync(x => x.Descripcion == venta.Descripcion))
                {
                    _context.PuntoVentas.Add(venta);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}