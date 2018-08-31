using Microsoft.EntityFrameworkCore;
using Sincosoft.Miraflores.Models;

namespace Sincosoft.Miraflores.Data.Repositorios
{
    public class RepositorioEfPeriodos : RepositorioEF<Periodo>
    {
        public RepositorioEfPeriodos(DbContext contextoBd) : base(contextoBd) {}
    }
}
