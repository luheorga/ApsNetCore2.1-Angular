using System;

namespace Sincosoft.Miraflores.Models
{
    public class Curso : EntidadBase 
    {
        public int MateriaFK { get; set; }
        public Materia Materia { get; set; }
        public int ProfesorFK { get; set; }
        public Profesor Profesor { get; set; }
        public int PeriodoFK { get; set; }
        public Periodo Periodo { get; set; }
        public string Descripcion { get; set; }
    }
}
