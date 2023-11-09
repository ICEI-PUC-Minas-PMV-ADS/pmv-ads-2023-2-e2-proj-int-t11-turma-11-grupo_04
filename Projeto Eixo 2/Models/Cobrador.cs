using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Eixo_2.Models
{
    [Table("Cobradores")]
    public class Cobrador
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Nome")]
        [Required(ErrorMessage = "É obrigatório informar o nome.")]
        public string NomeCobrador { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "É obrigatório informar o sobrenome.")]
        public string SobrenomeCobrador { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o CPF.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o Telefone.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a senha.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public ICollection<Cliente> Cliente { get; set; }
    }
}
