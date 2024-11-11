using ChefStock.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

public class RestauranteController : Controller
{
    // Simulando o banco de dados
    private static List<Restaurante> _restaurantes = new List<Restaurante>
    {
        new Restaurante { Id = 1, Nome = "Nome Atual", Email = "email@restaurante.com" }
    };

    // Exibe a página de edição do restaurante
    public IActionResult Index()
    {
        return View(_restaurantes.FirstOrDefault());
    }

    // Processa a alteração das informações do restaurante
    [HttpPost]
    public IActionResult Edit(Restaurante restaurante)
    {
        var restauranteExistente = _restaurantes.FirstOrDefault(r => r.Id == restaurante.Id);
        if (restauranteExistente != null)
        {
            restauranteExistente.Nome = restaurante.Nome;
            restauranteExistente.Email = restaurante.Email;
        }
        
        return RedirectToAction("Index");
    }
}
