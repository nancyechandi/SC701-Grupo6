using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Restaurante_API.Data;
using Restaurante_API.Models;
using System.Security.Claims;

namespace Restaurante_API.Controllers
{
    public class LoginController : Controller
    {
        private readonly RestauranteContext _context;

        public LoginController(RestauranteContext context)
        {
            _context = context;
        }

        [HttpGet("/Login")]
        public IActionResult Index()
        {
            return View(new Usuario());
        }

        [HttpPost("/Login")]
        public async Task<IActionResult> Login(string nombre, string clave)
        {
            var usuario = _context.Usuario.FirstOrDefault(u => u.nombre == nombre && u.clave == clave);

            if (usuario != null)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, usuario.nombre),
                    new Claim(ClaimTypes.Role, usuario.rol),
                    new Claim("usuario_id", usuario.usuario_id.ToString())
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                if (usuario.rol == "Cliente")
                {
                    return RedirectToAction("MenuCliente", "Home");
                }
                else if (usuario.rol == "Administrador")
                {
                    return RedirectToAction("MenuAdministrador", "Home");
                }
                else
                {
                    return RedirectToAction("Menu", "Home");
                }
            }

            return View("~/Views/Shared/Error.cshtml");
        }

        [HttpPost("/Registro")]
        public IActionResult Registro(Usuario usuario, string rol)
        {
            if (ModelState.IsValid)
            {
                usuario.rol = rol;
                _context.Usuario.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("Menu", "Home");
            }
            else
            {
                return View("~/Views/Login/Index.cshtml", usuario);
            }
        }
    }
}
