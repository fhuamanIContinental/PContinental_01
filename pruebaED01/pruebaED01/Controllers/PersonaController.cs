using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pruebaED01.Model;
using pruebaED01.Model.Common;
using pruebaED01.Repositorio;
using static pruebaED01.CustomSecurity.AuthorizeByRoleAttribute;

namespace pruebaED01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //QUE SI LA PETICIÓN NO TIENE EL TOKEN CORRESPONDIENTE 
    //A ESTE SE LE VA A DENEGAR LAS ACCIONES QUE OFRECE ESTE CONTROLADOR

    [Authorize]
    //[Authorize(Roles = "Administrator,RecursosHumanos")]
    //[RolesAuthorizeAttribute(recursos_humanos, administrador, contabilidad)]
    //Mostrar las opciones de menú por cada tipo de perfil

    public class PersonaController : ControllerBase
    {
        PersonaRepositorio _repo = new PersonaRepositorio();
        [HttpGet]
        public IActionResult getAll()
        {
            try
            {
                throw new Exception("The student cannot be found.");

                List<Persona> lst = _repo.getAll();
                return Ok(lst);
            }
            catch (Exception ex)
            {
                
                /*
                 
                 */
                
                CustomException exx = new CustomException("Error no controlado", 500, 500, "", ex);
                throw exx;
            }

          
        }
        [HttpGet("complete")]
        public IActionResult getAllComplete()
        {
            List<Persona> lst = _repo.getAllComplete();
            return Ok(lst);
        }


        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            try
            {
                Persona registro = _repo.getById(id);
                return Ok(registro);
            }
            catch (Exception ex)
            {

                CustomException exx = new CustomException("Error no controlado", 500, 500, "", ex);
                throw exx;
            }

            
        }

        [HttpPost]
        public IActionResult create([FromBody] Persona request)
        {

            

            Persona registro = _repo.create(request);
            return Ok(registro);
        }

        [HttpPut]
        public IActionResult update([FromBody] Persona request)
        {
            Persona registro = _repo.update(request);
            return Ok(registro);
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            int registro = _repo.delete(id);
            return Ok(registro);
        }
    }
}
