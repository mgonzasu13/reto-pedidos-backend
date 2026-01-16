using Microsoft.EntityFrameworkCore;
using Reto_Pedidos.Domain.Entities;

namespace Reto_Pedidos.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Pedido> Pedidos => Set<Pedido>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("Pedidos");

                entity.HasKey(p => p.Id);

                entity.Property(p => p.NumeroPedido)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(p => p.Cliente)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(p => p.Total)
                      .HasPrecision(18, 2);

                entity.Property(p => p.Estado)
                      .HasMaxLength(50);
            });
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");

                entity.HasKey(u => u.Id);

                entity.Property(u => u.Email)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(u => u.PasswordHash)
                      .IsRequired();

                entity.Property(u => u.Role)
                      .HasMaxLength(50);

                entity.HasIndex(u => u.Email)
                      .IsUnique();
            });
        }
    }
}
