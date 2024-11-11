using System.ComponentModel.DataAnnotations;

namespace SeuProjeto.Models
{
    public class ItemCompra
    {
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public decimal Preco { get; set; }

        public decimal Total => Quantidade * Preco;
    }
}
