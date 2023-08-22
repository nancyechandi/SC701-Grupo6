using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Restaurante_API.Data;

namespace Restaurante_API.Controllers
{
    public class HomeController : Controller
    {
        private readonly RestauranteContext _context;

        public HomeController(RestauranteContext context)
        {
            _context = context;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/MenuCliente")]
        [Authorize(Roles = "Cliente")]
        public IActionResult MenuCliente()
        {
            var platillos = _context.Platillo.ToList();
            return View("~/Views/MenuCliente/Index.cshtml", platillos);
        }

        [HttpGet("/MenuAdministrador")]
        [Authorize(Roles = "Administrador")]
        public IActionResult MenuAdministrador()
        {
            var platillos = _context.Platillo.ToList();
            return View("~/Views/Menu/Index.cshtml", platillos);
        }

        [HttpGet("/Menu")]
        public IActionResult Menu()
        {
            var platillos = _context.Platillo.ToList();
            return View("~/Views/MenuCliente/Index.cshtml", platillos);
        }

        [HttpPost("/Logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}
