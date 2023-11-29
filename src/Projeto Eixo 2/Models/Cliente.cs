using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Eixo_2.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Obrigatório informar o nome do cliente.")]
        public string NomeCliente { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "Obrigatório informar o sobrenome do cliente.")]
        public string SobrenomeCliente { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Obrigatório informar o CPF do cliente.")]
        public string CPFCliente { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "É obrigatório informar o endereço do cliente.")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o bairro do cliente.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a cidade do cliente.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o estado do cliente.")]
        public string UF { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Obrigatório informar o telefone do cliente.")]
        public string TelefoneCliente { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Obrigatório informar o e-mail do cliente")]
        public string Email { get; set; }


        public int CobradorId { get; set; }

        [ForeignKey("CobradorId")]
        public Cobrador Cobrador { get; set; }

    }
    public static class ClienteExtensions
    {
        public static string GetNomeCompleto(this Cliente cliente)
        {
            return $"{cliente.NomeCliente} {cliente.SobrenomeCliente}";
        }
    }
}
