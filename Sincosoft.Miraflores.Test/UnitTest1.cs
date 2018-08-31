using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sincosoft.Miraflores.Controllers;
using Sincosoft.Miraflores.Models;

namespace Sincosoft.Miraflores.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1()
        {
            var nuevoAlumno = new Alumno
            {
                Id = -1,
                Nombre = "Luis Hernando",
                Apellido = "Orjuela García"
            };
            //var controladorAlumnos = new AlumnoController();
            //var alumnoCreado = controladorAlumnos.CrearAlumno(nuevoAlumno);
            //Assert.IsTrue(alumnoCreado.Id > 0);
        }

        [TestMethod]
        public void Test2()
        {
            var primerAlumno = new Alumno
            {
                Nombre = "Juan",
                Apellido = "Contreras"
            };
            var segundoAlumno = new Alumno
            {
                Nombre = "Camilo",
                Apellido = "Cepeda"
            };
            //var controladorAlumnos = new AlumnoController();
            //var primerAdicion = controladorAlumnos.CrearAlumno(primerAlumno);
            //var segundaAdicion = controladorAlumnos.CrearAlumno(segundoAlumno);
            //Assert.IsTrue(primerAdicion.Id > 0);
            //Assert.IsTrue(segundaAdicion.Id > 0);
            //Assert.IsTrue(segundaAdicion.Id > primerAdicion.Id);
        }
        [TestMethod]
        public void Test3()
        {
            var alumnoACrear = new Alumno
            {
                Nombre = "Luis",
                Apellido = "Orjuela"
            };
            //var controladorAlumnosInstancia1 = new AlumnoController();
            //var controladorAlumnosInstancia2 = new AlumnoController();

            //var alumnoCreado1 = controladorAlumnosInstancia1.CrearAlumno(alumnoACrear);
            //var alumnoCreado2 = controladorAlumnosInstancia2.CrearAlumno(alumnoACrear);

            //Assert.IsTrue(alumnoCreado1.Id > 0);
            //Assert.IsTrue(alumnoCreado2.Id > 0);
            //Assert.IsTrue(alumnoCreado2.Id > alumnoCreado1.Id);

        }
    }
}
