using Microsoft.AspNetCore.Mvc;
using Sincosoft.Miraflores.Models;

namespace Sincosoft.Miraflores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private IRepositorio<Materia> _repositorioMaterias;
        public MateriaController(IRepositorio<Materia> repositorio)
        {
            _repositorioMaterias = repositorio;
        }

        [HttpGet("{id}")]
        public ActionResult<Materia> Get(int id)
        {
            var alumno = _repositorioMaterias.ObtenerPorId(id);
            if (alumno == null)
                return NotFound();
            return alumno;
        }

        [HttpPost]
        public ActionResult<Materia> CrearAlumno(Materia nuevoAlumno)
        {
            var resultado = _repositorioMaterias.Crear(nuevoAlumno);
            return CreatedAtAction("Get", new {id = resultado.Id}, resultado);
        }
        
        [HttpPut("{id}")]
        public ActionResult Actualizar(int id, Materia alumno)
        {
            alumno.Id = id;
            if (!MateriaExiste(id))
                return NotFound();
            _repositorioMaterias.Actualizar(alumno);
            return NoContent();
        }

        private bool MateriaExiste(int id)
        {
            return _repositorioMaterias.ObtenerPorId(id) == null;
        }
    }
}
