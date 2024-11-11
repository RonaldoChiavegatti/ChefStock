namespace ChefStock.Models
{
    public class OperacaoEntrada
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; } // Referência ao GrupoProduto
        public string ProdutoNome { get; set; } = string.Empty; // Nome do produto
        public int Quantidade { get; set; }
        public DateTime DataEntrada { get; set; }
    }
}
