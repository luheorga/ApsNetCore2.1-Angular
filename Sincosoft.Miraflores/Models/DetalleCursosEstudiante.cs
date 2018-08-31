namespace Sincosoft.Miraflores.Models
{
    public class DetalleCursosEstudiante : EntidadBase
    {
        public int AlumnoFK { get; set; }
        public Alumno Alumno { get; set; }
        public int CursoFK { get; set; }
        public Curso Curso { get; set; }
    }
}
