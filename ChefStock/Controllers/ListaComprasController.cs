using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefStock.Models;
using System.Threading.Tasks;
using SeuProjeto.Models;

namespace SeuProjeto.Controllers
{
    public class ListaComprasController : Controller
    {
        private readonly AppDbContext _context;

        public ListaComprasController(AppDbContext context)
        {
            _context = context;
        }

        // Método para exibir a lista de compras
        public async Task<IActionResult> Index()
        {
            var itensCompra = await _context.ItensCompra.ToListAsync();
            return View(itensCompra);
        }

        // Método para exibir o formulário de criação de item
        public IActionResult Criar()
        {
            return View();
        }

        // Método para adicionar um novo item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(ItemCompra item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // Método para excluir um item
        public async Task<IActionResult> Excluir(int id)
        {
            var item = await _context.ItensCompra.FindAsync(id);
            if (item != null)
            {
                _context.ItensCompra.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
