using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sincosoft.Miraflores.Data;
using Sincosoft.Miraflores.Data.Repositorios;
using Sincosoft.Miraflores.Models;

namespace Sincosoft.Miraflores
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MirafloresContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            RegistrarRepositorios(services);
        }

        private void RegistrarRepositorios(IServiceCollection services)
        {
            services.AddTransient<IRepositorio<Alumno>>(ctx =>
            {
                var dbContext = ctx.GetService<MirafloresContext>();
                return new RepositorioEfAlumnos(dbContext);
            }).AddTransient<IRepositorio<Materia>>(ctx =>
            {
                var dbContext = ctx.GetService<MirafloresContext>();
                return new RepositorioEfMaterias(dbContext);
            }).AddTransient<IRepositorio<Profesor>>(ctx =>
            {
                var dbContext = ctx.GetService<MirafloresContext>();
                return new RepositorioEfProfesores(dbContext);
            }).AddTransient<IRepositorio<Curso>>(ctx =>
            {
                var dbContext = ctx.GetService<MirafloresContext>();
                return new RepositorioEfCursos(dbContext);
            }).AddTransient<IRepositorio<Periodo>>(ctx =>
            {
                var dbContext = ctx.GetService<MirafloresContext>();
                return new RepositorioEfPeriodos(dbContext);
            });
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                InicializarBaseDeDatos(app);
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }

        private void InicializarBaseDeDatos(IApplicationBuilder app)
        {
            using (var ambitoServicios = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var contextoBd = ambitoServicios.ServiceProvider.GetService<MirafloresContext>();
                contextoBd.Database.EnsureDeleted();
                contextoBd.Database.EnsureCreated();
            }
        }
    }
}
