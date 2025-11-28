using ASPCoreMVC.DAL;
using ASPCoreMVC.Models;
using ASPCoreMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class AnimalController : Controller
{
    // GET: Animal/Details/5
    [HttpGet]
    public IActionResult Details(int id)
    {
        AnimalDAL dal = new AnimalDAL();

        // Obtener animal por id
        var animal = dal.GetById(id);

        if (animal == null)
        {
            return NotFound();
        }

        // Crear ViewModel para la vista
        DetailAnimalViewModel vm = new DetailAnimalViewModel
        {
            AnimalDetail = animal
        };

        return View(vm);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        AnimalDAL dal = new AnimalDAL();

        var animal = dal.GetById(id);
        if (animal == null)
            return NotFound();

        var tipos = dal.GetTipoAnimal();

        var vm = new FormViewModel
        {
            Animal = animal,
            TiposAnimal = tipos.Select(t => new SelectListItem
            {
                Value = t.IdTipoAnimal.ToString(),
                Text = t.TipoDescripcion,
                Selected = (t.IdTipoAnimal == animal.RIdTipoAnimal)
            }).ToList(),
            Title = "Editar Animal",
            ActionName = "Edit"
        };

        return View("Form", vm);
    }

    [HttpPost]
    public IActionResult Edit(FormViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            // Recargar lista si falla
            AnimalDAL dal = new AnimalDAL();
            vm.TiposAnimal = dal.GetTipoAnimal()
                .Select(t => new SelectListItem
                {
                    Value = t.IdTipoAnimal.ToString(),
                    Text = t.TipoDescripcion
                }).ToList();

            vm.Title = "Editar Animal";
            return View("Form", vm);
        }

        // Actualizar animal en la base de datos
        AnimalDAL animalDal = new AnimalDAL();
        animalDal.Update(vm.Animal);

        // Redirigir a la vista de detalles
        return RedirectToAction("Details", "Animal", new { id = vm.Animal.IdAnimal });
    }

    [HttpGet]
    public IActionResult Create()
    {
        AnimalDAL dal = new AnimalDAL();

        var tipos = dal.GetTipoAnimal();

        var vm = new FormViewModel
        {
            Animal = new Animal(),
            TiposAnimal = tipos.Select(t => new SelectListItem
            {
                Value = t.IdTipoAnimal.ToString(),
                Text = t.TipoDescripcion
            }).ToList(),
            Title = "Crear Nuevo Animal",
            ActionName = "Create"
        };

        return View("Form", vm);
    }

    [HttpPost]
    public IActionResult Create(FormViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            // Recargar lista de tipos si falla
            AnimalDAL dal = new AnimalDAL();
            vm.TiposAnimal = dal.GetTipoAnimal()
                .Select(t => new SelectListItem
                {
                    Value = t.IdTipoAnimal.ToString(),
                    Text = t.TipoDescripcion
                }).ToList();

            vm.Title = "Crear Nuevo Animal";
            return View("Form", vm);
        }

        // Guarda animal en la base de datos
        AnimalDAL animalDal = new AnimalDAL();
        animalDal.Create(vm.Animal);

        // Redirige a la lista principal
        return RedirectToAction("Index", "Home");
    }
}
