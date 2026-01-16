using Microsoft.EntityFrameworkCore;
using Reto_Pedidos.Domain.Entities;
using BCrypt.Net;

namespace Reto_Pedidos.Infrastructure.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Usuarios.Any())
            {
                context.Usuarios.Add(new Usuario
                {
                    Email = "admin@admin.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Role = "Admin"
                });

                context.SaveChanges();
            }
        }
    }
}
