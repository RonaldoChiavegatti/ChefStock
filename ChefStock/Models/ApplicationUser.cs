using Microsoft.AspNetCore.Identity;

namespace ChefStock.Models
{
    // Esta classe herda de IdentityUser para adicionar propriedades personalizadas ao usuário
    public class ApplicationUser : IdentityUser
    {
        // Exemplo de propriedade personalizada (nome completo)
        public required string FullName { get; set; }
        
        // Você pode adicionar outras propriedades conforme necessário
    }
}
