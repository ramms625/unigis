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
    public class ZonasController : CustomBaseController
    {
        private readonly ApplicationDbContext _context;
        public ZonasController(ApplicationDbContext context)
        {
            _context = context;
        }




        /// <summary>
        /// Endpoint para consulta de zonas
        /// </summary>
        /// <returns>Listado de zonas</returns>
        [HttpGet("GetAll")]
        [SwaggerOperation(Summary = "Get zonas", Description = "Devuelve un listado de zonas.")]
        [ProducesResponseType(typeof(ApiResponse<List<Zonas>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NoContentApiResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var zonas = await _context.Zonas.ToListAsync();
                return GetResponse(HttpStatusCode.OK, zonas);
            }
            catch (Exception ex)
            {
                return GetNoContentResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        /// <summary>
        /// Endpoint para consulta de zona por medio de su Id
        /// </summary>
        /// <returns>Una zona en específico</returns>
        [HttpGet("Get/{id:int}")]
        [SwaggerOperation(Summary = "Get zona por id", Description = "Devuelve una zona por su id.")]
        [ProducesResponseType(typeof(ApiResponse<Zonas>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NoContentApiResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(NoContentApiResponse), (int)HttpStatusCode.InternalServerError)]
        [ServiceFilter(typeof(FiltroExisteRecurso<Zonas>))]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var zona = await _context.Zonas.FirstOrDefaultAsync(x => x.Id == id);
                return GetResponse(HttpStatusCode.OK, zona!);
            }
            catch (Exception ex)
            {
                return GetNoContentResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}