using API_IngWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_IngWeb.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : Controller
    {
        [HttpGet]
        public ActionResult<List<Estudiante>> GetEstudiantes()
        {
            return EstudianteRepository.GetEstudiantes();
        }

        [HttpGet("{id}")]
        public ActionResult<Estudiante> GetEstudiante(int id)
        {
            var estudiante = EstudianteRepository.GetEstudianteId(id);
            if (estudiante == null)
                return NotFound();
            return estudiante;
        }

        [HttpPost]
        public ActionResult<Estudiante> AgregarEstudiante(Estudiante estudiante)
        {
            EstudianteRepository.AgregarEstudiante(estudiante);
            return CreatedAtAction(nameof(GetEstudiante), new { id = estudiante.Id }, estudiante);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarEstudiante(int id, Estudiante estudiante)
        {
            if (id != estudiante.Id)
                return BadRequest();
            EstudianteRepository.ActualizarEstudiante(estudiante);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarEstudiante(int id)
        {
            EstudianteRepository.EliminarEstudiante(id);
            return NoContent();
        }
    }
}
