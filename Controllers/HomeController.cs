using ASPCoreMVC.DAL;
using ASPCoreMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    // Acción principal que muestra la lista de animales y tipos
    public IActionResult Index()
    {
        AnimalDAL animalDal = new AnimalDAL();
        TipoAnimalDAL tipoAnimalDal = new TipoAnimalDAL();

        // Crear el ViewModel y llenar las listas usando los DAL
        AnimalViewModel viewModel = new AnimalViewModel
        {
            Animales = animalDal.GetAll(),
            TipoAnimales = tipoAnimalDal.GetAll()
        };

        return View(viewModel);
    }

    // Acción POST desde el botón "Ver Detalles" en la lista
    [HttpPost]
    public IActionResult AnimalDetails(int id)
    {
        // Redirige a la acción Details del AnimalController
        return RedirectToAction("Details", "Animal", new { id });
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
