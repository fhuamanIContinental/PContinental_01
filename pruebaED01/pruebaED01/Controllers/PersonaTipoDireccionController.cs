using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pruebaED01.Model;
using pruebaED01.Repositorio;

namespace pruebaED01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaTipoDireccionController : ControllerBase
    {

        PersonaTipoDireccionRepositorio _repo = new PersonaTipoDireccionRepositorio();
        [HttpGet]
        public IActionResult getAll()
        { 
            List<PersonaTipoDireccion> lst = _repo.getAll();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            PersonaTipoDireccion registro = _repo.getById(id);
            return Ok(registro);
        }

        [HttpPost]
        public IActionResult create([FromBody] PersonaTipoDireccion request)
        {
            PersonaTipoDireccion registro = _repo.create(request);
            return Ok(registro);
        }

        [HttpPut]
        public IActionResult update([FromBody] PersonaTipoDireccion request)
        {
            PersonaTipoDireccion registro = _repo.update(request);
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
