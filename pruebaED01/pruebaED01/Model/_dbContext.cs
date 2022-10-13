using Microsoft.EntityFrameworkCore;

namespace pruebaED01.Model
{
    public class _dbContext : DbContext
    {
        #region configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder configurationBuild = new ConfigurationBuilder();
            configurationBuild = configurationBuild.AddJsonFile("appsettings.json");
            IConfiguration configurationFile = configurationBuild.Build();

            // Leemos el archivo de configuración.
            optionsBuilder.EnableSensitiveDataLogging();
            string conneccion = configurationFile.GetConnectionString("dbInstituto");
            optionsBuilder.UseSqlServer(conneccion);
        }
        #endregion

        #region declare tables

        public DbSet<Persona> Persona { get; set; }
        public DbSet<PersonaTipoDireccion> PersonaTipoDireccion { get; set; }
        public DbSet<PersonaDireccion> PersonaDireccion { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            #region claves unicas
            modelBuilder.Entity<Persona>().HasIndex(p => new { p.numero_documento }).IsUnique();
            #endregion

            #region valores por defecto
            modelBuilder.Entity<Persona>().Property(p => p.fecha_registro).HasDefaultValue(DateTime.Now);
            #endregion

            #region carga data inicial

            modelBuilder.Entity<PersonaTipoDireccion>().HasData(
              new PersonaTipoDireccion { id = 1, descripcion = "Casa" },
              new PersonaTipoDireccion { id = 2, descripcion = "Trabajo" },
              new PersonaTipoDireccion { id = 3, descripcion = "Familiar" }
            );

            #endregion


        }

    }
}
