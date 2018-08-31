namespace Sincosoft.Miraflores.Models
{
    public class NotasCursoEstudiante : EntidadBase
    {
        public int DetalleCursosEstudianteFK { get; set; }
        public DetalleCursosEstudiante DetalleCursosEstudiante { get; set; }
        public double Nota { get; set; }
        public double Porcentaje { get; set; }
    }
}
