using Microsoft.AspNetCore.Mvc;
using System.Net;
using Unigis.PuntoVentas.BackEnd.Data.Models;

namespace Unigis.PuntoVentas.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        public CustomBaseController()
        {
            
        }


        protected IActionResult GetNoContentResponse(HttpStatusCode statusCode, string message = "")
        {
            return StatusCode((int)statusCode, new NoContentApiResponse(message));
        }


        protected IActionResult GetResponse(HttpStatusCode statusCode, object data, string message = "")
        {
            return StatusCode((int)statusCode, new ApiResponse<object>(message: message, data: data));
        }
    }
}