using System;
using EventosDeportivos.Dominio;
using Microsoft.EntityFrameworkCore;

namespace EventosDeportivos.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Arbitro> Arbitros { get; set; }

        public DbSet<CanchasEspacio> CanchasEspacios { get; set; }

        public DbSet<Deportista> Deportistas { get; set; }

        public DbSet<Entrenador> Entrenadores { get; set; }

        public DbSet<Equipo> Equipos { get; set; }

        public DbSet<Escenario> Escenarios { get; set; }

        public DbSet<EscuelaArbitro> Escuelas { get; set; }

        public DbSet<Municipio> Municipios { get; set; }

        public DbSet<Patrocinador> Patrocinadores { get; set; }

        public DbSet<Torneo> Torneos { get; set; }

        public DbSet<TorneoEquipo> TorneosEquipos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder oBuilder)
        {
            if (!oBuilder.IsConfigured)
            {
                oBuilder
                //Cadena de conexion a SQLServer para uso de leonardoapd
                     //.UseSqlServer("Data Source = localhost; User ID = sa; Password = Leoandres123; Application Name = EventosDeportivos; Initial Catalog = EventosDeportivosProject");
                //Utilice la siguiente cadena de conexion si posee la base de datos local y comente la linea anterior.
                    //.UseSqlServer("Data Source = (local)\\MSSQLServerLocalDB; Initial Catalog = EventosDeportivos");
                //Utilice esta cadena para conectarse a la base de datos en Azure
                    .UseSqlServer("Server=tcp:eventosdeportivos.database.windows.net,1433;Initial Catalog=EventosDeportivosProject;Persist Security Info=False;User ID=leonardoapd;Password=[introducircontraseña];MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        //Metodo sobrecargado para especificar que la tabla maestro detalle TorneoEquipo posee Ids
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<TorneoEquipo>().HasKey(x => new{x.EquipoId, x.TorneoId});
        } 
    }
}
