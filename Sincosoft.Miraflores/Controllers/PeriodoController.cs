using Microsoft.AspNetCore.Mvc;
using Sincosoft.Miraflores.Models;

namespace Sincosoft.Miraflores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodoController : ControllerBase
    {
        private IRepositorio<Periodo> _repositorioPeriodos;
        public PeriodoController(IRepositorio<Periodo> repositorio)
        {
            _repositorioPeriodos = repositorio;
        }

        [HttpGet("{id}")]
        public ActionResult<Periodo> Get(int id)
        {
            var profesor = _repositorioPeriodos.ObtenerPorId(id);
            if (profesor == null)
                return NotFound();
            return profesor;
        }

        [HttpPost]
        public ActionResult<Periodo> CrearAlumno(Periodo nuevoAlumno)
        {
            var resultado = _repositorioPeriodos.Crear(nuevoAlumno);
            return CreatedAtAction("Get", new {id = resultado.Id}, resultado);
        }
        
        [HttpPut("{id}")]
        public ActionResult Actualizar(int id, Periodo profesor)
        {
            profesor.Id = id;
            if (!ProfesorExiste(id))
                return NotFound();
            _repositorioPeriodos.Actualizar(profesor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Borrar(int id)
        {
            if (!ProfesorExiste(id))
                return NotFound();
            _repositorioPeriodos.Eliminar(id);
            return NoContent();
        }

        private bool ProfesorExiste(int id)
        {
            return _repositorioPeriodos.ObtenerPorId(id) == null;
        }
    }
}
