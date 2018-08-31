using Microsoft.EntityFrameworkCore;
using Sincosoft.Miraflores.Models;

namespace Sincosoft.Miraflores.Data.Repositorios
{
    public class RepositorioEfMaterias : RepositorioEF<Materia>
    {
        public RepositorioEfMaterias(DbContext contextoBd) : base(contextoBd)
        {
        }
    }
}
