using ASPCoreMVC.DAL;
using ASPCoreMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreMVC.Controllers
{
    public class AnimalController : Controller
    {
       /* public IActionResult Details(int id)
        {
            AnimalDAL dal = new AnimalDAL();
            DetailAnimalViewModel vm = new DetailAnimalViewModel();

            vm.AnimalDetail = dal.GetById(id);

            if (vm.AnimalDetail == null)
            {
                return NotFound();
            };

            return View(vm);
        }*/
    }
}
