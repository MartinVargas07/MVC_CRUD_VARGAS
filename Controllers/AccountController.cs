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
            var usuario = _context.LoginUsuarios.FirstOrDefault(u => u.Email == email && u.Clave == password);

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
            if (_context.LoginUsuarios.Any(u => u.Email == email))
            {
                ViewBag.ErrorMessage = "Este correo ya está registrado.";
                return View();
            }

            var nuevoUsuario = new LoginUsuario
            {
                Nombre = nombre,
                Email = email,
                Clave = password
            };

            _context.LoginUsuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync();

            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
