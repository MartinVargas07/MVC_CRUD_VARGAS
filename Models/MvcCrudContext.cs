using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC_CRUD_VARGAS.Models
{
    public partial class MvcCrudContext : DbContext
    {
        public MvcCrudContext()
        {
        }

        public MvcCrudContext(DbContextOptions<MvcCrudContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<LoginUsuario> LoginUsuarios { get; set; }  // Nueva tabla para usuarios de login

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC0707E36348");

                entity.Property(e => e.Clave)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            // Configuración de LoginUsuarios (si es necesario)
            modelBuilder.Entity<LoginUsuario>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__LoginUsuarios__3214EC0712345678");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Clave)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
