namespace ASPCoreMVC.Models.ViewModels
{
    public class AnimalViewModel
    {
        public List<Animal> Animales { get; set; } = new List<Animal>();

        public List<TipoAnimal> TipoAnimales { get; set; } = new List<TipoAnimal>();
    }
}
