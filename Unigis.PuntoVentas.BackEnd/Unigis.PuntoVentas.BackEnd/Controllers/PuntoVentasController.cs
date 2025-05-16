using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using Unigis.PuntoVentas.BackEnd.Data;
using Unigis.PuntoVentas.BackEnd.Data.Entidades;
using Unigis.PuntoVentas.BackEnd.Data.Models;
using Unigis.PuntoVentas.BackEnd.Filtros;

namespace Unigis.PuntoVentas.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuntoVentasController : CustomBaseController
    {
        private readonly ApplicationDbContext _context;
        public PuntoVentasController(ApplicationDbContext context)
        {
            _context = context;
        }



        /// <summary>
        /// Endpoint para consulta de puntos de venta
        /// </summary>
        /// <returns>Listado de puntos de venta</returns>
        [HttpGet("GetAll")]
        [SwaggerOperation(Summary = "Get puntos de venta", Description = "Devuelve un listado de los puntos de venta.")]
        [ProducesResponseType(typeof(ApiResponse<List<Zonas>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NoContentApiResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var ventas = await _context.PuntoVentas.ToListAsync();
                return GetResponse(HttpStatusCode.OK, ventas);
            }
            catch (Exception ex)
            {
                return GetNoContentResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        /// <summary>
        /// Endpoint para consulta de un punto de venta por medio de su Id
        /// </summary>
        /// <returns>Un punto de venta en específico</returns>
        [HttpGet("Get/{id:int}")]
        [SwaggerOperation(Summary = "Get punto de venta por id", Description = "Devuelve un punto de venta por su id.")]
        [ProducesResponseType(typeof(ApiResponse<Zonas>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NoContentApiResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(NoContentApiResponse), (int)HttpStatusCode.InternalServerError)]
        [ServiceFilter(typeof(FiltroExisteRecurso<PuntoDeVentas>))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var venta = await _context.PuntoVentas.FirstOrDefaultAsync(x => x.Id == id);
                return GetResponse(HttpStatusCode.OK, venta!);
            }
            catch (Exception ex)
            {
                return GetNoContentResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }




        /// <summary>
        /// Endpoint para actualizar un punto de venta por medio de su Id
        /// </summary>
        /// <returns>Registro actualizado</returns>
        [HttpPut("Delete/{id:int}")]
        [SwaggerOperation(Summary = "Update punto de venta", Description = "Actualiza un punto de venta en base a su id.")]
        [ProducesResponseType(typeof(ApiResponse<PuntoDeVentas>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NoContentApiResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(NoContentApiResponse), (int)HttpStatusCode.InternalServerError)]
        [ServiceFilter(typeof(FiltroExisteRecurso<PuntoDeVentas>))]
        public async Task<IActionResult> Update([FromRoute] int id)
        {
            try
            {
                var venta = await _context.PuntoVentas.FirstOrDefaultAsync(x => x.Id == id);

                _context.PuntoVentas.Remove(venta!);
                await _context.SaveChangesAsync();

                return GetResponse(HttpStatusCode.OK, venta!);
            }
            catch (Exception ex)
            {
                return GetNoContentResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }




        /// <summary>
        /// Endpoint para eliminar un punto de venta por medio de su Id
        /// </summary>
        /// <returns>Mensaje de estatus</returns>
        [HttpDelete("Delete/{id:int}")]
        [SwaggerOperation(Summary = "Delete punto de venta", Description = "Elimina un punto de venta en base a su id.")]
        [ProducesResponseType(typeof(NoContentApiResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NoContentApiResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(NoContentApiResponse), (int)HttpStatusCode.InternalServerError)]
        [ServiceFilter(typeof(FiltroExisteRecurso<PuntoDeVentas>))]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var venta = await _context.PuntoVentas.FirstOrDefaultAsync(x => x.Id == id);
                
                _context.PuntoVentas.Remove(venta!);
                await _context.SaveChangesAsync();

                return GetNoContentResponse(HttpStatusCode.OK, "Registro eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return GetNoContentResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        private async Task<bool> ExisteZona(int idZona)
        {
            return await _context.Zonas.AnyAsync(x => x.Id == idZona);
        }
    }
}