using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante_API.Data;
using Restaurante_API.Models;

namespace Restaurante_API.Controllers
{
    public class ReservacionController : Controller
    {
        private readonly RestauranteContext _context;
        public ReservacionController(RestauranteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Restaurantes = _context.Restaurante.ToList();
            return View(_context.Reservacion.ToList());
        }

        [HttpPost]
        public IActionResult AddReservacion(Reservacion reservacion)
        {
            var usuarioIdClaim = User.FindFirst("usuario_id");
            if (usuarioIdClaim != null && int.TryParse(usuarioIdClaim.Value, out int usuarioId))
            {
                reservacion.usuario_id = usuarioId;
                reservacion.restaurante_id = 1; 
                if (ModelState.IsValid)
                {
                    _context.Reservacion.Add(reservacion);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

    }
}

