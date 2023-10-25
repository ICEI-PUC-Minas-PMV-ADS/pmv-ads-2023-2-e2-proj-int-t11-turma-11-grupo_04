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

        [Required(ErrorMessage = "Obrigatório informar o nome.")]
        [RegularExpression(@"^[a-zA-ZÀ-ú\s]+$", ErrorMessage = "O nome deve conter apenas letras.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o email.")]
        [EmailAddress(ErrorMessage = "O email não está em um formato válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o CPF.")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O CPF não está em um formato válido.")]
        [StringLength(14, ErrorMessage = "O CPF não deve ter mais que 14 caracteres.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o telefone!")]
        [RegularExpression(@"^\(\d{2}\)\d{4}-\d{4}$", ErrorMessage = "O telefone não está em um formato válido.")]
        public string Telefone { get; set; }

        [ForeignKey("CobradorId")]
        [Required(ErrorMessage = "É obrigatório informar o cobrador.")]
        public int CobradorId { get; set; }
        public Cobrador Cobrador { get; set; }

    }
}
