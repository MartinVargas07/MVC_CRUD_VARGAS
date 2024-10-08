using Microsoft.AspNetCore.Mvc;

namespace MVC_CRUD_VARGAS.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
