using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Reto_Pedidos.Infrastructure.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IJwtService _jwt;

        public AuthController(AppDbContext context, IJwtService jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        [EnableRateLimiting("login")]
        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Usuarios.FirstOrDefault(x => x.Email == email);
            if (user == null)
                return Unauthorized("Credenciales inválidas");

            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return Unauthorized("Credenciales inválidas");

            var token = _jwt.GenerateToken(user);

            return Ok(new { token });
        }
    }
}
