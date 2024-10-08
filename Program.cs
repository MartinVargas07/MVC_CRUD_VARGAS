using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MVC_CRUD_VARGAS.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddControllersWithViews();

// Configurar el contexto de la base de datos (Entity Framework)
builder.Services.AddDbContext<MvcCrudContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

// Configurar la autenticaci�n basada en cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        // Ruta donde redirigir en caso de que el usuario no est� autenticado
        options.LoginPath = "/Account/Login";
        // Ruta para el cierre de sesi�n
        options.LogoutPath = "/Account/Logout";
        // Ruta opcional para acceso denegado
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

var app = builder.Build();

// Configurar el manejo de excepciones para producci�n
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // El valor predeterminado de HSTS es 30 d�as, puedes cambiarlo en producci�n
    app.UseHsts();
}

// Habilitar redirecci�n HTTPS
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Habilitar autenticaci�n y autorizaci�n
app.UseAuthentication();
app.UseAuthorization();

// Configurar las rutas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
