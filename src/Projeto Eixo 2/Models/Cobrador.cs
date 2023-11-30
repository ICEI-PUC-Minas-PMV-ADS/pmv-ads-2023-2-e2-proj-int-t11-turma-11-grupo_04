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
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o CEP.")]
        public string CEP { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "É obrigatório informar o endereço.")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o bairro.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a cidade.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o estado.")]
        public string UF { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o telefone.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a senha.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o perfil.")]
        public Perfil Perfil { get; set; } = Perfil.User;

        [Display(Name = "Foto")]
        public string FotoUrl { get; set; } // Caminho ou URL da foto

        [NotMapped] // Esta propriedade não será mapeada no banco de dados
        [Display(Name = "Carregar Foto")]
        public IFormFile FotoArquivo { get; set; } // Propriedade para lidar com o upload do arquivo

        public ICollection<Cliente> Cliente { get; set; }
        public ICollection<Cobranca> Cobranca { get; set; }

    }
    public enum Perfil
    {
        Admin,
        User
    }
}
