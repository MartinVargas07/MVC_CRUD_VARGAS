using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using MVC_CRUD_VARGAS.Models;
using System.Threading.Tasks;
using System.Linq;

namespace MVC_CRUD_VARGAS.Controllers
{
    public class AccountController : Controller
    {
        private readonly MvcCrudContext _context;

        public AccountController(MvcCrudContext context)
        {
            _context = context;
        }

        // Mostrar la vista de Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Manejar la lógica del login
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Clave == password);

            if (usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Nombre),
                    new Claim(ClaimTypes.Email, usuario.Email)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("Welcome", "Account");
            }

            ViewBag.ErrorMessage = "Correo o contraseña incorrectos";
            return View();
        }

        // Mostrar la vista de registro
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Manejar la lógica de registro
        [HttpPost]
        public async Task<IActionResult> Register(string nombre, string email, string password)
        {
            // Verificar si el correo ya está registrado
            if (_context.Usuarios.Any(u => u.Email == email))
            {
                ViewBag.ErrorMessage = "Este correo ya está registrado.";
                return View();
            }

            // Crear un nuevo usuario
            var nuevoUsuario = new Usuario
            {
                Nombre = nombre,
                Email = email,
                Clave = password
            };

            _context.Usuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync();

            // Después del registro, redirigir al login
            return RedirectToAction("Login", "Account");
        }

        // Cerrar sesión
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
