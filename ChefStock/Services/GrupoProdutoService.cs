using ChefStock.Models;

namespace ChefStock.Services
{
    public class GrupoProdutoService : IGrupoProdutoService
    {
        private static List<GrupoProduto> _grupoProdutos = new List<GrupoProduto>();

        public List<GrupoProduto> GetAllGrupoProdutos()
        {
            return _grupoProdutos;
        }

        public GrupoProduto GetGrupoProdutoById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _grupoProdutos.Find(g => g.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public void AddGrupoProduto(GrupoProduto grupoProduto)
        {
            grupoProduto.Id = _grupoProdutos.Count + 1;
            _grupoProdutos.Add(grupoProduto);
        }

        public void UpdateGrupoProduto(GrupoProduto grupoProduto)
        {
            var existingGrupoProduto = _grupoProdutos.Find(g => g.Id == grupoProduto.Id);
            if (existingGrupoProduto != null)
            {
                existingGrupoProduto.Nome = grupoProduto.Nome;
                existingGrupoProduto.Descricao = grupoProduto.Descricao;
                existingGrupoProduto.Quantidade = grupoProduto.Quantidade;
            }
        }

        public void DeleteGrupoProduto(int id)
        {
            var grupoProduto = _grupoProdutos.Find(g => g.Id == id);
            if (grupoProduto != null)
            {
                _grupoProdutos.Remove(grupoProduto);
            }
        }

        // Método para atualizar a quantidade de um produto (usado ao registrar uma entrada)
        public void AtualizarQuantidadeProduto(int produtoId, int quantidadeEntrada)
        {
            var grupoProduto = _grupoProdutos.Find(g => g.Id == produtoId);
            if (grupoProduto != null)
            {
                grupoProduto.Quantidade += quantidadeEntrada;
            }
        }

        // Método que já existia para busca de produto por nome
#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
        public GrupoProduto GetGrupoProdutoByNome(string produtoNome)
#pragma warning restore CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _grupoProdutos.FirstOrDefault(g => g.Nome.Equals(produtoNome, StringComparison.OrdinalIgnoreCase));
#pragma warning restore CS8603 // Possible null reference return.
        }

        public string? GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
