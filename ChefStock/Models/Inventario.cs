public class Inventario
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public Produto? Produto { get; set; }
    public DateTime DataMovimentacao { get; set; }
    public int Quantidade { get; set; }
    public TipoMovimentacao TipoMovimentacao { get; set; } // Entrada ou Saída
}
