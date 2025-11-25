using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPCoreMVC.Models;

public class AnimalController : Controller
{
    private readonly AbrilAnimalesContext _context;

    // Inyección de dependencia
    public AnimalController(AbrilAnimalesContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // EF obtiene todos los animales incluyendo su tipo
        var animales = _context.Animals
                               .Include(a => a.RIdTipoAnimalNavigation)
                               .ToList();

        return View(animales); // Pasamos los datos a la vista
    }
}
