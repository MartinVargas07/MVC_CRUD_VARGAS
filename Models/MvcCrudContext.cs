using Microsoft.EntityFrameworkCore;

namespace MVC_CRUD_VARGAS.Models
{
    public partial class MvcCrudContext : DbContext
    {
        public MvcCrudContext(DbContextOptions<MvcCrudContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<LoginUsuario> LoginUsuarios { get; set; }  // Tabla para autenticación

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Clave).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Fecha).HasColumnType("date");
            });

            modelBuilder.Entity<LoginUsuario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Clave).HasMaxLength(50).IsUnicode(false);
            });
        }
    }
}
