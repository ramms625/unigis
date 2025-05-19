using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using Unigis.PuntoVentas.BackEnd.Data;
using Unigis.PuntoVentas.BackEnd.Data.DTOs;
using Unigis.PuntoVentas.BackEnd.Data.Entidades;
using Unigis.PuntoVentas.BackEnd.Data.Models;
using Unigis.PuntoVentas.BackEnd.Filtros;

namespace Unigis.PuntoVentas.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuntoVentasController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public PuntoVentasController(
            IMapper mapper,
            ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }



        /// <summary>
        /// Endpoint para consulta de puntos de venta
        /// </summary>
        /// <returns>Listado de puntos de venta</returns>
        [HttpGet("GetAll")]
        [SwaggerOperation(Summary = "Get puntos de venta.", Description = "Devuelve un listado de los puntos de venta.")]
        [ProducesResponseType(typeof(ApiResponse<List<PuntoDeVentasDTO>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NoContentApiResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var ventas = await _context.PuntoVentas.Include(x => x.Zona).ToListAsync();

                var ventasDTO = _mapper.Map<List<PuntoDeVentasDTO>>(ventas);

                return GetResponse(HttpStatusCode.OK, ventasDTO);
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
        [SwaggerOperation(Summary = "Get punto de venta por id.", Description = "Devuelve un punto de venta por su id.")]
        [ProducesResponseType(typeof(ApiResponse<PuntoDeVentasDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NoContentApiResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(NoContentApiResponse), (int)HttpStatusCode.InternalServerError)]
        [ServiceFilter(typeof(FiltroExisteRecurso<PuntoDeVentas>))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var venta = await _context.PuntoVentas.Include(x => x.Zona).FirstOrDefaultAsync(x => x.Id == id);

                var ventaDTO = _mapper.Map<PuntoDeVentasDTO>(venta);

                return GetResponse(HttpStatusCode.OK, ventaDTO);
            }
            catch (Exception ex)
            {
                return GetNoContentResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }








        /// <summary>
        /// Endpoint para creación de un punto de venta
        /// </summary>
        /// <returns>El punto de venta creado</returns>
        [HttpPost("Post")]
        [SwaggerOperation(Summary = "Post punto de venta.", Description = "Devuelve el punto de venta creado.")]
        [ProducesResponseType(typeof(ApiResponse<PuntoDeVentasDTO>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ApiResponse<List<string>>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentApiResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(NoContentApiResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] PuntoDeVentasCreacionDTO puntoVentaCreacionDTO)
        {
            try
            {
                if (!await ExisteZona(puntoVentaCreacionDTO.IdZona))
                    return GetNoContentResponse(HttpStatusCode.NotFound, "La zona no existe");


                var nuevoPuntoCreacion = _mapper.Map<PuntoDeVentas>(puntoVentaCreacionDTO);


                var zona = await _context.Zonas.FirstOrDefaultAsync(x => x.Id == puntoVentaCreacionDTO.IdZona);
                nuevoPuntoCreacion.Zona = zona;


                _context.PuntoVentas.Add(nuevoPuntoCreacion);
                await _context.SaveChangesAsync();


                var puntoCreacionDTO = _mapper.Map<PuntoDeVentasDTO>(nuevoPuntoCreacion);


                return GetResponse(HttpStatusCode.Created, puntoCreacionDTO, message: "Punto de venta creado correctamente.");
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
        [HttpPut("Update/{id:int}")]
        [SwaggerOperation(Summary = "Update punto de venta.", Description = "Actualiza un punto de venta en base a su id.")]
        [ProducesResponseType(typeof(ApiResponse<PuntoDeVentas>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<List<string>>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentApiResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(NoContentApiResponse), (int)HttpStatusCode.InternalServerError)]
        [ServiceFilter(typeof(FiltroExisteRecurso<PuntoDeVentas>))]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PuntoDeVentasCreacionDTO puntoVentaCreacionDTO)
        {
            try
            {
                if (!await ExisteZona(puntoVentaCreacionDTO.IdZona))
                    return GetNoContentResponse(HttpStatusCode.NotFound, "La zona no existe");


                var zona = await _context.Zonas.FirstOrDefaultAsync(x => x.Id == puntoVentaCreacionDTO.IdZona);


                var venta = await _context.PuntoVentas.FirstOrDefaultAsync(x => x.Id == id);

                venta.Descripcion = puntoVentaCreacionDTO.Descripcion;
                venta.IdZona = puntoVentaCreacionDTO.IdZona;
                venta.Latitud = puntoVentaCreacionDTO.Latitud;
                venta.Longitud = puntoVentaCreacionDTO.Longitud;
                venta.Ventas = puntoVentaCreacionDTO.Ventas;
                venta.Zona = zona;


                _context.PuntoVentas.Update(venta);
                await _context.SaveChangesAsync();

                var puntoVentasDTO = _mapper.Map<PuntoDeVentasDTO>(venta);


                return GetResponse(HttpStatusCode.OK, puntoVentasDTO, "Punto de venta editado correctamente.");
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
        [SwaggerOperation(Summary = "Delete punto de venta.", Description = "Elimina un punto de venta en base a su id.")]
        [ProducesResponseType(typeof(NoContentApiResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NoContentApiResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(NoContentApiResponse), (int)HttpStatusCode.InternalServerError)]
        [ServiceFilter(typeof(FiltroExisteRecurso<PuntoDeVentas>))]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var venta = await _context.PuntoVentas.FirstOrDefaultAsync(x => x.Id == id);
                
                _context.PuntoVentas.Remove(venta);
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