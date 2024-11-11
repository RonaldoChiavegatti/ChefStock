using ChefStock.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class FuncionarioController : Controller
{
    private static List<Funcionario> _funcionarios = new List<Funcionario>
    {
        new Funcionario { Id = 1, Nome = "Funcionário 1", Email = "funcionario1@email.com", Senha = "senha123" },
        new Funcionario { Id = 2, Nome = "Funcionário 2", Email = "funcionario2@email.com", Senha = "senha123" }
    };

    // Exibe a página de gerenciamento de funcionários
    public IActionResult Index()
    {
        return View(_funcionarios);
    }

    // Processa a criação de um novo funcionário
    [HttpPost]
    public IActionResult Create(Funcionario funcionario)
    {
        funcionario.Id = _funcionarios.Count + 1;
        _funcionarios.Add(funcionario);
        return RedirectToAction("Index");
    }

    // Processa a exclusão de um funcionário
    public IActionResult Delete(int id)
    {
        var funcionario = _funcionarios.FirstOrDefault(f => f.Id == id);
        if (funcionario != null)
        {
            _funcionarios.Remove(funcionario);
        }
        return RedirectToAction("Index");
    }

    // Exibe a página de edição do funcionário
    public IActionResult Edit(int id)
    {
        var funcionario = _funcionarios.FirstOrDefault(f => f.Id == id);
        return View(funcionario);
    }

    // Processa a atualização das informações do funcionário
    [HttpPost]
    public IActionResult Edit(Funcionario funcionario)
    {
        var funcionarioExistente = _funcionarios.FirstOrDefault(f => f.Id == funcionario.Id);
        if (funcionarioExistente != null)
        {
            funcionarioExistente.Nome = funcionario.Nome;
            funcionarioExistente.Email = funcionario.Email;
            funcionarioExistente.Senha = funcionario.Senha;
        }

        return RedirectToAction("Index");
    }
}
