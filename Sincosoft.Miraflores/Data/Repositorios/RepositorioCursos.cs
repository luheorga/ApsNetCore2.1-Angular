using Microsoft.EntityFrameworkCore;
using Sincosoft.Miraflores.Models;

namespace Sincosoft.Miraflores.Data.Repositorios
{
    public class RepositorioEfCursos : RepositorioEF<Curso>
    {
        public RepositorioEfCursos(DbContext contextoBd) : base(contextoBd) {}
    }
}
