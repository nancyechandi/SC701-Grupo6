using Microsoft.AspNetCore.Mvc;
using Restaurante_API.Data;
using Restaurante_API.Models;
using System.Text;
namespace Restaurante_API.Controllers { 
    public class CarritoController : Controller
    {
        private readonly RestauranteContext _context;
        private static List<CarritoItem> carrito = new List<CarritoItem>();

        public CarritoController(RestauranteContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var platillosDisponibles = _context.Platillo.Where(p => p.cantidad > 0).ToList();
            ViewBag.Carrito = carrito;
            return View(platillosDisponibles);
        }

        [HttpPost]
        public IActionResult AgregarAlCarrito(int platilloId)
        {
            var platillo = _context.Platillo.FirstOrDefault(p => p.platillo_id == platilloId);
            if (platillo != null && platillo.cantidad > 0)
            {
                platillo.cantidad -= 1;
                _context.SaveChanges();

                var item = carrito.FirstOrDefault(i => i.Platillo.platillo_id == platilloId);
                if (item != null)
                {
                    item.Cantidad += 1;
                }
                else
                {
                    carrito.Add(new CarritoItem { Platillo = platillo, Cantidad = 1 });
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoverDelCarrito(int platilloId)
        {
            var platillo = _context.Platillo.FirstOrDefault(p => p.platillo_id == platilloId);
            if (platillo != null)
            {
                platillo.cantidad += 1;
                _context.SaveChanges();

                var item = carrito.FirstOrDefault(i => i.Platillo.platillo_id == platilloId);
                if (item != null)
                {
                    if (item.Cantidad > 1)
                    {
                        item.Cantidad -= 1;
                    }
                    else
                    {
                        carrito.Remove(item);
                    }
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult GenerarRecibo()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Recibo de Compra");
            sb.AppendLine("----------------");
            foreach (var item in carrito)
            {
                sb.AppendLine($"{item.Platillo.nombre} - Cantidad: {item.Cantidad}");
                var platillo = _context.Platillo.FirstOrDefault(p => p.platillo_id == item.Platillo.platillo_id);
                if (platillo != null)
                {
                    platillo.cantidad -= item.Cantidad;
                }
            }
            var filePath = "Data/recibo.txt";
            System.IO.File.WriteAllText(filePath, sb.ToString());
            carrito.Clear();
            return RedirectToAction("Index");
        }
    }
    public class CarritoItem
    {
        public Platillo Platillo { get; set; }
        public int Cantidad { get; set; }
    }
}
