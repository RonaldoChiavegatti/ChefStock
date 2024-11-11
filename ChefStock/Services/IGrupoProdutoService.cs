using ChefStock.Models;

namespace ChefStock.Services
{
    public interface IGrupoProdutoService
    {
        List<GrupoProduto> GetAllGrupoProdutos();
        GrupoProduto GetGrupoProdutoById(int id);
        void AddGrupoProduto(GrupoProduto grupoProduto);
        void UpdateGrupoProduto(GrupoProduto grupoProduto);
        void DeleteGrupoProduto(int id);
        string? GetAll();
        GrupoProduto GetGrupoProdutoByNome(string? produtoNome);
    }
}
