using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurante_API.Data;
using Restaurante_API.Models;

namespace Restaurante_API.Controllers
{
    public class PromocionesClienteController : Controller
    {
        private readonly RestauranteContext _context;

        public PromocionesClienteController(RestauranteContext context)
        {
            _context = context;
        }

        // GET: PromocionesCliente
        public async Task<IActionResult> Index()
        {
              return _context.Promocion != null ? 
                          View(await _context.Promocion.ToListAsync()) :
                          Problem("Entity set 'RestauranteContext.Promocion'  is null.");
        }

        
    }
}
