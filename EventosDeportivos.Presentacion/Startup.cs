using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EventosDeportivos.Persistencia;

namespace EventosDeportivos.Presentacion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllersWithViews();
            //services.AddSingleton<IRepositorioMunicipio, RepositorioMunicipio>(); //No sirve
            //Inyeccion de dependencia
            services.AddScoped<IRepositorioMunicipio, RepositorioMunicipio>(); //Sirve (?)
            services.AddScoped<IRepositorioEntrenador, RepositorioEntrenador>();
            services.AddScoped<IRepositorioTorneo, RepositorioTorneo>();
            services.AddScoped<IRepositorioEquipo, RepositorioEquipo>();
            services.AddScoped<IRepositorioDeportista, RepositorioDeportista>();
            services.AddScoped<IRepositorioArbitro, RepositorioArbitro>();
            services.AddScoped<IRepositorioEscenario, RepositorioEscenario>();
            services.AddScoped<IRepositorioCanchasEspacios, RepositorioCanchasEspacios>();
            services.AddScoped<IRepositorioPatrocinador, RepositorioPatrocinador>();
            services.AddScoped<IRepositorioTorneoEquipo, RepositorioTorneoEquipo>();
            //Registrar un contexto de datos
            services.AddDbContext<EventosDeportivos.Persistencia.AppContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapRazorPages();
            });
        }
    }
}
