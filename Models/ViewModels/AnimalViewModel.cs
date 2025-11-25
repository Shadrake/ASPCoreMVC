namespace ASPCoreMVC.Models.ViewModels
{
    // Para mostrar las tablas de la base de datos
    public class AnimalViewModel
    {
        // Lista-tabla de Animal
        public List<Animal> Animales { get; set; } = new List<Animal>();
        // Lista-tabla de TipoAnimales
        public List<TipoAnimal> TipoAnimales { get; set; } = new List<TipoAnimal>();
    }
}
