namespace Sincosoft.Miraflores.Models
{
    public interface IRepositorio<T> where T : EntidadBase
    {
        T Crear(T entidad);
        T ObtenerPorId(int id);
        void Actualizar(T entidad);
        void Eliminar(int id);
    }
}