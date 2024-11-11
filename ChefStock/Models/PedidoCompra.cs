public class PedidoCompra
{
    public int Id { get; set; }
    public DateTime DataPedido { get; set; }
    public int FornecedorId { get; set; }
    public Fornecedor? Fornecedor { get; set; }
    public decimal Total { get; set; }

    public ICollection<ItemPedidoCompra>? Itens { get; set; }
}
