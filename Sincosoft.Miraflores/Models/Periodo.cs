namespace Sincosoft.Miraflores.Models
{
    public class Periodo : EntidadBase
    {
        public int Anho { get; set; }
        public PeriodoAnho PeriodoAnho { get; set; }
    }

    public enum PeriodoAnho
    {
        Primero,
        Segundo
    }
}
