using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace turma11_grupo04.Models
{
    [Table("Cobrador")]
    public class Cobrador
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o nome.")]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a cidade.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "É obrigatório informar no CPF.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o CEP.")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o telefone.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o E-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a Senha.")]
        public string Senha { get; set; }   
    }
}
