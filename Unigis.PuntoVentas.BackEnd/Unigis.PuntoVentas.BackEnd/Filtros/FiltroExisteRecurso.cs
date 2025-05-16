using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Unigis.PuntoVentas.BackEnd.Data;
using Unigis.PuntoVentas.BackEnd.Data.Models;

namespace Unigis.PuntoVentas.BackEnd.Filtros
{
    /// <summary>
    /// Valida si existe algún recurso dentro de la base en base a la entidad solicitada
    /// </summary>
    /// <typeparam name="T">Entidad a validar</typeparam>
    public class FiltroExisteRecurso<T> : IAsyncResourceFilter where T : class, IId
    {
        private readonly ApplicationDbContext _context;
        public FiltroExisteRecurso(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            var objectId = context.HttpContext.Request.RouteValues["id"];

            if (objectId == null)
            {
                context.Result = NotFound("No se encontró un Id.");
                return;
            }

            if (!int.TryParse(objectId.ToString(), out int id))
            {
                context.Result = NotFound("El Id no es un valor numérico.");
                return;
            }


            var existe = await _context.Set<T>().AsNoTracking().AnyAsync(x => x.Id == id);



            if (!existe)
                context.Result = NotFound("No se encontró el recurso solicitado.");
            else
                await next();
        }


        private static NotFoundObjectResult NotFound(string message)
        {
            return new NotFoundObjectResult(new NoContentApiResponse(message));
        }
    }
}