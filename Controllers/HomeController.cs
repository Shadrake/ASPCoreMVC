using ASPCoreMVC.DAL;
using ASPCoreMVC.Models;
using ASPCoreMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            AnimalDAL dal = new AnimalDAL(_configuration);
            TipoAnimalDAL dalTipoAnimal = new TipoAnimalDAL(_configuration);

            AnimalViewModel viewModel = new AnimalViewModel
            {
                Animales = dal.GetAll(),
                TipoAnimales = dalTipoAnimal.GetAll()
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
