using System.ComponentModel.DataAnnotations;

namespace SeuProjeto.ViewModels
{
    public class RegistroViewModel
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Senha { get; set; }

        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "As senhas não coincidem.")]
        public required string ConfirmacaoSenha { get; set; }
    }
}
