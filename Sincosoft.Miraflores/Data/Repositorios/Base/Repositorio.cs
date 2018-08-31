using System;
using Microsoft.EntityFrameworkCore;

namespace Sincosoft.Miraflores.Models
{
    public class RepositorioEF<T> : IRepositorio<T> where T : EntidadBase
    {
        public DbContext _contextoBd;

        public RepositorioEF(DbContext contextoBd)
        {
            _contextoBd = contextoBd;
        }
    
        public virtual T Crear(T entidad)
        {
            var trackingEntity = _contextoBd.Set<T>().Add(entidad);
            _contextoBd.SaveChanges();
            return trackingEntity.Entity;
        }

        public virtual T ObtenerPorId(int id)
        {
            return _contextoBd.Set<T>().Find(id);
        }

        public virtual void Actualizar(T entidad)
        {
            _contextoBd.Entry(entidad).State = EntityState.Modified;
            _contextoBd.SaveChanges();
        }

        public virtual void Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
