using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace turma11_grupo04.Models
{
    [Table("Cliente")]
    public class Cliente
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

        [ForeignKey("CobradorId")]
        [Required(ErrorMessage = "É obrigatório informar o Cobrador.")]
        public int CobradorId { get; set; }

        public Cobrador Cobrador { get; set; }
    }
}
