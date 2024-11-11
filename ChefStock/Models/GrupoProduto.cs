namespace ChefStock.Models
{
    public class GrupoProduto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;  // Valor padrão
    public string Descricao { get; set; } = string.Empty;  // Valor padrão
    public int Quantidade { get; set; }
}

}
