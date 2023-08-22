using Microsoft.AspNetCore.Mvc;
using Restaurante_API.Data;
public class CategoriasController : Controller
{
    private readonly RestauranteContext _context;
    public CategoriasController(RestauranteContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var platillosVeganos = _context.Platillo.Where(p => p.vegano).ToList();
        var platillosGluten = _context.Platillo.Where(p => p.gluten).ToList();
        ViewData["Veganos"] = platillosVeganos;
        ViewData["Gluten"] = platillosGluten;
        return View();
    }
}
