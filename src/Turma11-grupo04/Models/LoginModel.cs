using System.ComponentModel.DataAnnotations;

namespace Turma11_grupo04.Models
{
    public class LoginModel
    {


        [Required(ErrorMessage = "É obrigatório informar o E-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a senha.")]
        public string Senha { get; set; }

    }
}
