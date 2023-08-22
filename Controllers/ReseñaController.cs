using Microsoft.AspNetCore.Mvc;
using Restaurante_API.Data;
using Restaurante_API.Models;
namespace Restaurante_API.Controllers
{
    public class ReseñaController : Controller
    {
        private readonly RestauranteContext _context;
        public ReseñaController(RestauranteContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            int restauranteId = 1;
                var restaurante = _context.Restaurante.FirstOrDefault(r => r.restaurante_id == restauranteId);
                if (restaurante != null)
                {
                    ViewData["Restaurante"] = restaurante;
                    var reseñasRestaurante = _context.Reseña.Where(r => r.restaurante_id == restauranteId).ToList();
                    ViewBag.RestauranteId = restauranteId;
                    return View(reseñasRestaurante);
                }
            
            return View();
        }
        [HttpPost]
        public IActionResult AddReseña(Reseña reseña)
        {
            var usuarioIdClaim = User.FindFirst("usuario_id");
            if (usuarioIdClaim != null)
            {
                int usuarioId = int.Parse(usuarioIdClaim.Value);
            
                reseña.usuario_id = usuarioId;
                reseña.restaurante_id = 1;
            }
            if (ModelState.IsValid)
            {
                _context.Reseña.Add(reseña);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", new { restauranteId = reseña.restaurante_id });
        }
    }
}
