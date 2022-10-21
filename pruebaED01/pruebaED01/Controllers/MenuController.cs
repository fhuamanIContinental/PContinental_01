using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pruebaED01.Constantes;
using pruebaED01.Model.Common;
using pruebaED01.Negocio;
using System.Net;

namespace pruebaED01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    //[AllowAnonymous]
    public class MenuController : ControllerBase
    {
        MenuNegocio _menuNegocio = new MenuNegocio();
        //localhost:7258/api/menu (get post put delete)
        //Verbo ==> GET POST PUT DELETE
        //[HttpVerbo("asignación de ruta personalizada/{id}/{id_persona}")] ==> id significa una variable

        //localhost:7258/api/menu
        [HttpGet("role/{id}")] // ==> localhost:7258/api/menu/role/1
        //[HttpDelete("role/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(MenuResponse))]
        public IActionResult getByRole(short id)
        {
            try
            {
                List<MenuResponse> response = _menuNegocio.getByRole(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Ocurrio un error al obtener un menú", (int)HttpStatusCode.InternalServerError, ConstansResponse.ERROR_NO_CONTROLADO_CODIGO, "No Controlado", ex);
                throw exx;
            }
        }

    }
}
