using Microsoft.AspNetCore.Mvc;
using Sincosoft.Miraflores.Models;

namespace Sincosoft.Miraflores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private IRepositorio<Alumno> _repositorioAlumnos;
        public AlumnoController(IRepositorio<Alumno> repositorio)
        {
            _repositorioAlumnos = repositorio;
        }

        [HttpGet("{id}")]
        public ActionResult<Alumno> Get(int id)
        {
            var alumno = _repositorioAlumnos.ObtenerPorId(id);
            if (alumno == null)
                return NotFound();
            return alumno;
        }

        [HttpPost]
        public ActionResult<Alumno> CrearAlumno(Alumno nuevoAlumno)
        {
            var resultado = _repositorioAlumnos.Crear(nuevoAlumno);
            return CreatedAtAction("Get", new {id = resultado.Id}, resultado);
        }
        
        [HttpPut("{id}")]
        public ActionResult Actualizar(int id, Alumno alumno)
        {
            alumno.Id = id;
            if (!AlumnoExiste(id))
                return NotFound();
            _repositorioAlumnos.Actualizar(alumno);
            return NoContent();
        }

        private bool AlumnoExiste(int id)
        {
            return _repositorioAlumnos.ObtenerPorId(id) == null;
        }
    }
}
