using ChefStock.Models;
using ChefStock.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ChefStock.Controllers
{
    public class GrupoProdutoController : Controller
    {
        private readonly IGrupoProdutoService _grupoProdutoService;

        public GrupoProdutoController(IGrupoProdutoService grupoProdutoService)
        {
            _grupoProdutoService = grupoProdutoService;
        }

        // GET: GrupoProduto
        public IActionResult Index()
        {
            var grupoProdutos = _grupoProdutoService.GetAllGrupoProdutos();
            return View(grupoProdutos);
        }

        // GET: GrupoProduto/Create
        public IActionResult Create()
        {
            return View(new GrupoProduto());
        }

        // POST: GrupoProduto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GrupoProduto grupoProduto)
        {
            if (ModelState.IsValid)
            {
                _grupoProdutoService.AddGrupoProduto(grupoProduto);
                TempData["SuccessMessage"] = "Grupo de produto criado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = "Erro ao criar o grupo de produto. Verifique os dados e tente novamente.";
            return View(grupoProduto);
        }

        // GET: GrupoProduto/Edit/5
        public IActionResult Edit(int id)
        {
            var grupoProduto = _grupoProdutoService.GetGrupoProdutoById(id);
            if (grupoProduto == null)
            {
                TempData["ErrorMessage"] = "Grupo de produto não encontrado.";
                return NotFound();
            }
            return View(grupoProduto);
        }

        // POST: GrupoProduto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, GrupoProduto grupoProduto)
        {
            if (id != grupoProduto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var existingProduto = _grupoProdutoService.GetGrupoProdutoById(id);
                if (existingProduto == null)
                {
                    TempData["ErrorMessage"] = "Grupo de produto não encontrado.";
                    return NotFound();
                }

                _grupoProdutoService.UpdateGrupoProduto(grupoProduto);
                TempData["SuccessMessage"] = "Grupo de produto atualizado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = "Erro ao atualizar o grupo de produto. Verifique os dados e tente novamente.";
            return View(grupoProduto);
        }

        // GET: GrupoProduto/Delete/5
        public IActionResult Delete(int id)
        {
            var grupoProduto = _grupoProdutoService.GetGrupoProdutoById(id);
            if (grupoProduto == null)
            {
                TempData["ErrorMessage"] = "Grupo de produto não encontrado.";
                return NotFound();
            }
            return View(grupoProduto);
        }

        // POST: GrupoProduto/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var grupoProduto = _grupoProdutoService.GetGrupoProdutoById(id);
            if (grupoProduto != null)
            {
                _grupoProdutoService.DeleteGrupoProduto(id);
                TempData["SuccessMessage"] = "Grupo de produto excluído com sucesso!";
            }
            else
            {
                TempData["ErrorMessage"] = "Erro ao excluir o grupo de produto. Grupo não encontrado.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
