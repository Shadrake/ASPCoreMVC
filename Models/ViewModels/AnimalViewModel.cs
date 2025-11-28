using System.Collections.Generic;
using ASPCoreMVC.Models;

namespace ASPCoreMVC.Models.ViewModels
{
    // Para mostrar las tablas de la base de datos
    public class AnimalViewModel
    {
        public List<Animal> Animales { get; set; } = new List<Animal>();
        public List<TipoAnimal> TipoAnimales { get; set; } = new List<TipoAnimal>();
    }
}
