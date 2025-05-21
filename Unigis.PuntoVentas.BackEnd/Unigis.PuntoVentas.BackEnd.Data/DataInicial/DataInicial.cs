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
            await AddPuntoVentasIniciales();
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
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear las zonas: {ex.Message}");
            }
        }


        private async Task AddPuntoVentasIniciales()
        {
            try
            {
                var ventas = new List<PuntoDeVentas>
            {
                new () { Descripcion = "Negocio 1", IdZona = 1, Latitud = 19.4352M, Longitud = -99.1412M, Ventas = 120000 },
                new () { Descripcion = "Negocio 2", IdZona = 2, Latitud = 19.4844M, Longitud = -99.1172M, Ventas = 87400 },
                new () { Descripcion = "Negocio 3", IdZona = 3, Latitud = 19.3322M, Longitud = -99.1882M, Ventas = 141000 },
                new () { Descripcion = "Negocio 4", IdZona = 4, Latitud = 19.4361M, Longitud = -99.0719M, Ventas = 43000 },
                new () { Descripcion = "Negocio 5", IdZona = 5, Latitud = 19.3616M, Longitud = -99.2760M, Ventas = 97300 },
                new () { Descripcion = "Negocio 6", IdZona = 1, Latitud = 19.4359M, Longitud = -99.1462M, Ventas = 170000 },
                new () { Descripcion = "Negocio 7", IdZona = 2, Latitud = 19.4939M, Longitud = -99.1218M, Ventas = 57000 },
                new () { Descripcion = "Negocio 8", IdZona = 3, Latitud = 19.2624M, Longitud = -99.1047M, Ventas = 68000 },
                new () { Descripcion = "Negocio 9", IdZona = 4, Latitud = 19.3579M, Longitud = -99.0676M, Ventas = 51000 },
                new () { Descripcion = "Negocio 10", IdZona = 5, Latitud = 19.4542M, Longitud = -99.2215M, Ventas = 77600 }
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
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear los puntos de venta: {ex.Message}");
            }
        }
    }
}