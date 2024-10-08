using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace MVC_CRUD_VARGAS.Controllers
{
    public class AccountController : Controller
    {
        // Mostrar la vista de Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Manejar la lógica del login
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Simulación básica de autenticación. Aquí deberías agregar tu lógica de autenticación.
            if (username == "admin" && password == "password")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    // Aquí puedes agregar propiedades adicionales (opcional)
                };

                // Iniciar sesión del usuario
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index", "Home"); // Redirigir al Home tras iniciar sesión
            }

            // Intento de inicio de sesión fallido
            ViewBag.ErrorMessage = "Usuario o contraseña incorrectos";
            return View();
        }

        // Manejar el cierre de sesión
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // Cerrar sesión del usuario
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
