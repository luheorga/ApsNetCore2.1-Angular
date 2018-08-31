using Microsoft.AspNetCore.Mvc;
using Sincosoft.Miraflores.Models;

namespace Sincosoft.Miraflores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private IRepositorio<Curso> _repositorioCursos;
        public CursoController(IRepositorio<Curso> repositorio)
        {
            _repositorioCursos = repositorio;
        }

        [HttpGet("{id}")]
        public ActionResult<Curso> Get(int id)
        {
            var alumno = _repositorioCursos.ObtenerPorId(id);
            if (alumno == null)
                return NotFound();
            return alumno;
        }

        [HttpPost]
        public ActionResult<Curso> Crear(Curso nuevoAlumno)
        {
            var resultado = _repositorioCursos.Crear(nuevoAlumno);
            return CreatedAtAction("Get", new {id = resultado.Id}, resultado);
        }
        
        [HttpPut("{id}")]
        public ActionResult Actualizar(int id, Curso alumno)
        {
            alumno.Id = id;
            if (!Existe(id))
                return NotFound();
            _repositorioCursos.Actualizar(alumno);
            return NoContent();
        }

        private bool Existe(int id)
        {
            return _repositorioCursos.ObtenerPorId(id) == null;
        }
    }
}
