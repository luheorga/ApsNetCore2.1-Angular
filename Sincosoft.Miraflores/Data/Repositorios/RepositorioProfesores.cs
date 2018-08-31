using Microsoft.EntityFrameworkCore;
using Sincosoft.Miraflores.Models;

namespace Sincosoft.Miraflores.Data.Repositorios
{
    public class RepositorioEfProfesores : RepositorioEF<Profesor>
    {
        public RepositorioEfProfesores(DbContext contextoBd) : base(contextoBd) {}
    }
}
