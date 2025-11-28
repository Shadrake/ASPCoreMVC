using ASPCoreMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class AnimalDAL
{
    private string connectionString;

    public AnimalDAL()
    {
        // Leer la cadena de conexión directamente del appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Carpeta raíz del proyecto
            .AddJsonFile("appsettings.json")
            .Build();

        connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    private AbrilAnimalesContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<AbrilAnimalesContext>()
            .UseSqlServer(connectionString)
            .Options;

        return new AbrilAnimalesContext(options);
    }

    public List<Animal> GetAll()
    {
        using var context = CreateContext();
        return context.Animals.Include(a => a.TipoAnimal).ToList();
    }

    public Animal GetById(int id)
    {
        using var context = CreateContext();
        return context.Animals.Include(a => a.TipoAnimal)
                              .FirstOrDefault(a => a.IdAnimal == id);
    }

    public void Update(Animal updatedAnimal)
    {
        using var context = CreateContext();
        context.Animals.Update(updatedAnimal);
        context.SaveChanges();
    }

    public void Create(Animal createdAnimal)
    {
        using var context = CreateContext();
        context.Animals.Add(createdAnimal);
        context.SaveChanges();
    }

    public List<TipoAnimal> GetTipoAnimal()
    {
        using var context = CreateContext();
        return context.TipoAnimal.ToList();
    }

}
