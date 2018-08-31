using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sincosoft.Miraflores.Models;

namespace Sincosoft.Miraflores.Data
{
    public class MirafloresContext : DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<DetalleCursosEstudiante> CursosEstudiante { get; set; }
        public DbSet<Periodo> Periodos { get; set; }
        public DbSet<NotasCursoEstudiante> NotasCursoEstudiante { get; set; }

        public MirafloresContext() { }

        public MirafloresContext(DbContextOptions<MirafloresContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Curso>()
                .HasOne(x => x.Materia)
                .WithMany()
                .HasForeignKey(curso => curso.MateriaFK);
            builder.Entity<Curso>()
                .HasOne(x => x.Profesor)
                .WithMany()
                .HasForeignKey(curso => curso.ProfesorFK);
            builder.Entity<Curso>()
                .HasOne(x => x.Periodo)
                .WithMany()
                .HasForeignKey(curso => curso.PeriodoFK);
            builder.Entity<DetalleCursosEstudiante>()
                .HasOne(x => x.Alumno)
                .WithMany()
                .HasForeignKey(cursoEstudiante => cursoEstudiante.AlumnoFK);
            builder.Entity<DetalleCursosEstudiante>()
                .HasOne(x => x.Curso)
                .WithMany()
                .HasForeignKey(cursoEstudiante => cursoEstudiante.CursoFK);
            builder.Entity<DetalleCursosEstudiante>()
                .HasIndex(cursoEstudiante => new { cursoEstudiante.AlumnoFK, cursoEstudiante.CursoFK })
                .IsUnique();
            var converter = new EnumToStringConverter<PeriodoAnho>();
            builder.Entity<Periodo>()
                .Property(e => e.PeriodoAnho)
                .HasConversion(converter);
            builder.Entity<NotasCursoEstudiante>()
                .HasOne(x => x.DetalleCursosEstudiante)
                .WithMany()
                .HasForeignKey(curso => curso.DetalleCursosEstudianteFK);
        }

    }
}
