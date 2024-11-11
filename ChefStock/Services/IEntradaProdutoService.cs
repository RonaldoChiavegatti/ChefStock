using ChefStock.Services;

public class EntradaProdutoService : IEntradaProdutoService
{
    private readonly IGrupoProdutoService _grupoProdutoService;

    public EntradaProdutoService(IGrupoProdutoService grupoProdutoService)
    {
        _grupoProdutoService = grupoProdutoService;
    }

    public void DarEntrada(int produtoId, int quantidade)
    {
        var grupoProduto = _grupoProdutoService.GetGrupoProdutoById(produtoId);
        if (grupoProduto != null)
        {
            grupoProduto.Quantidade += quantidade; // Adiciona a quantidade ao produto
            _grupoProdutoService.UpdateGrupoProduto(grupoProduto); // Atualiza o produto
        }
    }
}

public interface IEntradaProdutoService
{
}