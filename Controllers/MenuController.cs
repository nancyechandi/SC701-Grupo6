using Microsoft.AspNetCore.Mvc;
using Restaurante_API.Data;
public class MenuController : Controller
{
    private readonly RestauranteContext _context;

    public MenuController(RestauranteContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var platillos = _context.Platillo.ToList();
        var usuarioRol = HttpContext.Session.GetString("UsuarioRol");

        if (usuarioRol == "Administrador")
        {
            return View("IndexAdministrador", platillos);
        }
        else if (usuarioRol == "Cliente")
        {
            return View("IndexCliente", platillos);
        }
        else
        {
            return View("~/Views/Error.cshtml");
        }
    }

    [HttpPost]
    public IActionResult AgregarPlatillo(int platilloId)
    {
        var platillo = _context.Platillo.FirstOrDefault(p => p.platillo_id == platilloId);
        if (platillo != null)
        {
            platillo.cantidad += 1;
            _context.SaveChanges();

            ViewBag.CantidadPlatillo = platillo.cantidad;
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult RemoverPlatillo(int platilloId)
    {
        var platillo = _context.Platillo.FirstOrDefault(p => p.platillo_id == platilloId);
        if (platillo != null && platillo.cantidad > 0)
        {
            platillo.cantidad -= 1;
            _context.SaveChanges();

            ViewBag.CantidadPlatillo = platillo.cantidad;
        }

        return RedirectToAction("Index");
    }
}
