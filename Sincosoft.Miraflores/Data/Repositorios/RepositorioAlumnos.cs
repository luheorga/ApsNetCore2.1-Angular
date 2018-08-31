using Microsoft.EntityFrameworkCore;
using Sincosoft.Miraflores.Models;

namespace Sincosoft.Miraflores.Data.Repositorios
{
    public class RepositorioEfAlumnos : RepositorioEF<Alumno>
    {
        public RepositorioEfAlumnos(DbContext contextoBd) : base(contextoBd)
        {
        }
    }
}
