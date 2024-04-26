using System.ComponentModel.DataAnnotations;

namespace AgendaApp.MVC.Models.Account
{
    public class AccountLoginViewModel
    {
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do usuário.")]
        public string? Email { get; set; }

        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe uma senha.")]
        public string? Senha {  get; set; }

    }
}
