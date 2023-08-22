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
    public class EventosClienteController : Controller
    {
        private readonly RestauranteContext _context;

        public EventosClienteController(RestauranteContext context)
        {
            _context = context;
        }

        // GET: EventosCliente
        public async Task<IActionResult> Index()
        {
              return _context.Evento != null ? 
                          View(await _context.Evento.ToListAsync()) :
                          Problem("Entity set 'RestauranteContext.Evento'  is null.");
        }

        
    }
}
