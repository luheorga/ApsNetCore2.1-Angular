using Microsoft.AspNetCore.Mvc;
using Sincosoft.Miraflores.Models;

namespace Sincosoft.Miraflores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private IRepositorio<Profesor> _repositorioProfesores;
        public ProfesorController(IRepositorio<Profesor> repositorio)
        {
            _repositorioProfesores = repositorio;
        }

        [HttpGet("{id}")]
        public ActionResult<Profesor> Get(int id)
        {
            var profesor = _repositorioProfesores.ObtenerPorId(id);
            if (profesor == null)
                return NotFound();
            return profesor;
        }

        [HttpPost]
        public ActionResult<Profesor> CrearAlumno(Profesor nuevoAlumno)
        {
            var resultado = _repositorioProfesores.Crear(nuevoAlumno);
            return CreatedAtAction("Get", new {id = resultado.Id}, resultado);
        }
        
        [HttpPut("{id}")]
        public ActionResult Actualizar(int id, Profesor profesor)
        {
            profesor.Id = id;
            if (!ProfesorExiste(id))
                return NotFound();
            _repositorioProfesores.Actualizar(profesor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Borrar(int id)
        {
            if (!ProfesorExiste(id))
                return NotFound();
            _repositorioProfesores.Eliminar(id);
            return NoContent();
        }

        private bool ProfesorExiste(int id)
        {
            return _repositorioProfesores.ObtenerPorId(id) == null;
        }
    }
}
