using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using MVC_CRUD_VARGAS.Models; // Asegúrate de que se referencia tu modelo

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

        // Manejar la lógica del login con correo y contraseña
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            // Autenticar con correo y contraseña
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Clave == password);

            if (usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Nombre),
                    new Claim(ClaimTypes.Email, usuario.Email)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    // Aquí puedes agregar propiedades adicionales (opcional)
                };

                // Iniciar sesión
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Welcome", "Account"); // Redirigir a la pantalla de bienvenida
            }

            // Si las credenciales no son correctas
            ViewBag.ErrorMessage = "Correo o contraseña incorrectos";
            return View();
        }

        // Mostrar la pantalla de bienvenida tras el login
        [HttpGet]
        public IActionResult Welcome()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            return View((object)email); // Pasamos el email a la vista
        }

        // Cerrar sesión
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account"); // Redirigir a la pantalla de login
        }
    }
}
