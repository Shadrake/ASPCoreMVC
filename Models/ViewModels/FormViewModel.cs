using System.Collections.Generic;
using ASPCoreMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

public class FormViewModel
{

    public Animal Animal { get; set; }
    public List<SelectListItem> TiposAnimal { get; set; }

    // Para usar el mismo formulario con Create o Edit
    public string Title { get; set; }

    // para indicar Create o Edit
    public string ActionName { get; set; } 

}
