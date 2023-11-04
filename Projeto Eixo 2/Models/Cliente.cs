using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Eixo_2.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome do cliente.")]
        public string NomeCliente { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o sobrenome do cliente.")]
        public string SobrenomeCliente { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o CPF do cliente.")]
        public string CPFCliente { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o telefone do cliente.")]
        public string TelefoneCliente { get; set; }

        public int CobradorId { get; set; }

        [ForeignKey("CobradorId")]
        public Cobrador Cobrador { get; set; }

    }
}
