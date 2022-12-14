using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace pruebaED01.Model
{
    public partial class _dbContext : DbContext
    {
        public _dbContext()
        {
        }

        public _dbContext(DbContextOptions<_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<MenuRole> MenuRoles { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<PersonaDireccion> PersonaDireccions { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<TipoDireccion> TipoDireccions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuRole>(entity =>
            {
                entity.HasOne(d => d.IdMenuNavigation)
                    .WithMany(p => p.MenuRoles)
                    .HasForeignKey(d => d.IdMenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__menu_role__id_me__60A75C0F");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.MenuRoles)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__menu_role__id_ro__619B8048");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.Property(e => e.FechaRegistro).HasDefaultValueSql("('2022-09-28T20:42:22.1731965-05:00')");
            });

            modelBuilder.Entity<PersonaDireccion>(entity =>
            {
                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.PersonaDireccions)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdTipoDireccionNavigation)
                    .WithMany(p => p.PersonaDireccions)
                    .HasForeignKey(d => d.IdTipoDireccion)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user__id_person__5CD6CB2B");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user__id_role__5DCAEF64");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
