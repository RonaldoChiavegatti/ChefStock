using System.ComponentModel.DataAnnotations;

namespace SeuProjeto.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Senha { get; set; }

        public bool Lembrar { get; set; }
    }
}
