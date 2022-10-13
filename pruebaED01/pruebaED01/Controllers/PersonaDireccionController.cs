using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pruebaED01.Model;
using pruebaED01.Repositorio;

namespace pruebaED01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaDireccionController : ControllerBase
    {
        PersonaDireccionRepositorio _repo = new PersonaDireccionRepositorio();
        
        [HttpGet]
        public IActionResult getAll()
        {
            List<PersonaDireccion> lst = _repo.getAll();
            return Ok(lst);
        }

        [HttpGet("complete")]
        public IActionResult getAllComplete()
        {
            List<PersonaDireccion> lst = _repo.getAllComplete();
            return Ok(lst);
        }


        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            PersonaDireccion registro = _repo.getById(id);
            return Ok(registro);
        }

        [HttpPost]
        public IActionResult create([FromBody] PersonaDireccion request)
        {
            PersonaDireccion registro = _repo.create(request);
            return Ok(registro);
        }

        [HttpPut]
        public IActionResult update([FromBody] PersonaDireccion request)
        {
            PersonaDireccion registro = _repo.update(request);
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