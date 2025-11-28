using ASPCoreMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class TipoAnimalDAL
{
    private string connectionString;

    public TipoAnimalDAL()
    {
        // Leer la cadena de conexión directamente desde appsettings.json
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

    // Obtener todos los tipos de animales
    public List<TipoAnimal> GetAll()
    {
        using var context = CreateContext();
        return context.TipoAnimal.ToList();
    }

    // Obtener un tipo de animal por su Id
    public TipoAnimal GetById(int id)
    {
        using var context = CreateContext();
        return context.TipoAnimal.FirstOrDefault(t => t.IdTipoAnimal == id);
    }
}