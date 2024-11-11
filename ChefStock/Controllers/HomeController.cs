using ChefStock.Models; 
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var model = new IndexModel
        {
            Message = "Bem-vindo ao ChefStock!"
        };

        return View(model);
    }

    public IActionResult Sobre()
    {
        return View();
    }
}
