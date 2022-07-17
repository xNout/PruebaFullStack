using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaN5.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaN5.INFRASTRUCTURE.REPOSITORY.SQLSERVER
{
    public class N5DBContext : DbContext
    {
        
        public N5DBContext()
        {
        }

        public N5DBContext(DbContextOptions<N5DBContext> options)
            : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //        optionsBuilder.UseSqlServer(configuration["DBConnectionString"]);
            
        //}
        public virtual DbSet<Permiso> Permisos { get; set; } = null!;
        public virtual DbSet<TipoPermiso> TipoPermisos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.Property(e => e.ApellidoEmpleado)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaPermiso).HasColumnType("datetime");

                entity.Property(e => e.NombreEmpleado)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoPermiso>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

        }
    }
}
