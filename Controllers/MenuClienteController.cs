using Microsoft.AspNetCore.Mvc;
using Restaurante_API.Data;

namespace Restaurante_API.Controllers
{
    public class MenuClienteController : Controller
    {
        private readonly RestauranteContext _context;

        public MenuClienteController(RestauranteContext context)
        {
            _context = context;
        }
        public IActionResult Index(string search)
        {
            var platillos = _context.Platillo.ToList();

            if (!string.IsNullOrEmpty(search))
            {
                platillos = platillos.Where(p => p.nombre.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            Console.WriteLine(platillos);

            return View(platillos);
        }
    }
}
