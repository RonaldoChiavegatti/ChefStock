using ChefStock.Models;

namespace ChefStock.Models
{
    public class Restaurante
    {
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public object? Id { get; internal set; }
    }
}
