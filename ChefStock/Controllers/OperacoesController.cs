using ChefStock.Models;
using ChefStock.Services; // Acessando o serviço de GrupoProduto
using Microsoft.AspNetCore.Mvc;

namespace ChefStock.Controllers
{
    public class OperacoesController : Controller
    {
        private readonly IGrupoProdutoService _grupoProdutoService;
        private static List<OperacaoEntrada> _operacoesEntrada = new List<OperacaoEntrada>();

        // Injeção de dependência do serviço de GrupoProduto
        public OperacoesController(IGrupoProdutoService grupoProdutoService)
        {
            _grupoProdutoService = grupoProdutoService;
        }

        // GET: Operacoes/EntradaProdutos
        public IActionResult EntradaProdutos()
        {
            var grupoProdutos = _grupoProdutoService.GetAllGrupoProdutos(); // Certifique-se de que isso retorna uma lista válida
            ViewBag.GrupoProdutos = grupoProdutos ?? new List<GrupoProduto>(); // Evita `null` se a lista estiver vazia
            return View();
        }


        // POST: Operacoes/EntradaProdutos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EntradaProdutos(OperacaoEntrada operacaoEntrada)
        {
            if (ModelState.IsValid)
            {
                // Buscar o produto pelo nome na lista _grupoProdutos
                var produto = _grupoProdutoService.GetGrupoProdutoById(operacaoEntrada.ProdutoId);

                if (produto == null)
                {
                    ModelState.AddModelError("ProdutoNome", "Produto não encontrado!");
                    var grupoProdutos = _grupoProdutoService.GetAllGrupoProdutos();
                    ViewBag.GrupoProdutos = grupoProdutos;
                    return View(operacaoEntrada);
                }

                // Registra a entrada de produtos
                operacaoEntrada.Id = _operacoesEntrada.Count + 1; // Atribui um ID simples
                operacaoEntrada.DataEntrada = DateTime.Now; // Registra a data de entrada

                produto.Quantidade += operacaoEntrada.Quantidade; // Atualiza a quantidade do produto no estoque
                _operacoesEntrada.Add(operacaoEntrada); // Adiciona a operação de entrada à lista

                return RedirectToAction("Index", "GrupoProduto");
            }

            // Caso o ModelState não seja válido, envia de volta a lista de produtos
            var grupoProdutosList = _grupoProdutoService.GetAllGrupoProdutos();
            ViewBag.GrupoProdutos = grupoProdutosList;
            return View(operacaoEntrada);
        }
    }
}
