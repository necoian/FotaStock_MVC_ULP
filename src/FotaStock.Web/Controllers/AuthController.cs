using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FotaStock.Web.Context;
using FotaStock.Web.Entities;
using FotaStock.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FotaStock.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public AuthController(AppDbContext context, IConfiguration configuration, IWebHostEnvironment enviroment)
        {
            _context = context;
            _configuration = configuration;
            _env =enviroment;
        }

        public class LoginRequest
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] UsuarioVM usuarioVM)
        {
            

            
            if (await _context.Usuario.AnyAsync(u=>u.Nombre == usuarioVM.Nombre))
            {
                var error = "El usuario ya existe";
                return Ok(new { success = false, message = error });
            } else if(await _context.Usuario.AnyAsync(u=>u.Email == usuarioVM.Email))
            {
                var error = "El usuario ya existe";
                return Ok(new { success = false, message = error });
            }

            string? avatarURL = null;

            if (usuarioVM.Avatar != null && usuarioVM.Avatar.Length > 0)
            {
                var extensionesPermitidas = new[]
                {
                    ".jpg", ".jpeg", ".png" , ".webp"
                };
                var extension = Path.GetExtension(usuarioVM.Avatar.FileName).ToLowerInvariant();

                if(!extensionesPermitidas.Contains(extension))
                {
                    var error = "Formato invalido de archivo";
                    return Ok(new { success = false, message = error });
                }

                if (usuarioVM.Avatar.Length > 5 * 1024 * 1024)
                {
                    var error = "La imagen no puede superar los 5 megabytes";
                    return Ok(new { success = false, message = error });
                }

                var carpeta = Path.Combine(_env.WebRootPath ?? Path.Combine(_env.ContentRootPath, "wwwroot"),
                "subidos","avatares");

                Directory.CreateDirectory(carpeta);

                var nombreArchivo = $"{Guid.NewGuid()}{extension}";

                var rutaArchivo = Path.Combine(carpeta,nombreArchivo);

                using (var stream = new FileStream(rutaArchivo,FileMode.Create))
                {
                    await usuarioVM.Avatar.CopyToAsync(stream);
                }

                avatarURL = $"/subidos/avatares/{nombreArchivo}";

            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(usuarioVM.Password);

            var usuario = new Usuario
            {
                Nombre = usuarioVM.Nombre,
                Email = usuarioVM.Email,
                PasswordHash = passwordHash,
                Rol = usuarioVM.rol,
                FechaAlta = DateTime.Now,
                Avatar = avatarURL

            };




            
        

            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(new { success = false, message = "Usuario Registrado correctamente" });
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _context.Usuario.FirstOrDefaultAsync(u=>u.Nombre == request.username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.password, user.PasswordHash))
            {

                var error = "Usuario o contraseña incorrectas";
                return Ok(new { success = false, message = error });
                
            }

            var token = GenerateJwtToken(user.Nombre);
            SetJwtCookie((string)token);
            return Ok(new { success = true, redirectTo = Url.Action("Index", "Home") });
        }

        private void SetJwtCookie(string token)
        {
            Response.Cookies.Append("AuthToken", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = _env.IsProduction(),
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddMinutes(30)
            });
        }

        private object GenerateJwtToken(string nombre)
        {
            var jwtConfig = _configuration.GetSection("Jwt");
            var key = Encoding.UTF8.GetBytes(jwtConfig["Key"]);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,nombre),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                
            };
            var token = new JwtSecurityToken(
                issuer: jwtConfig["Issuer"],
                audience: jwtConfig["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256
                )
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
            

        }

        [HttpPost]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("AuthToken");
            return RedirectToAction(nameof(Login));

        }
    }
}
