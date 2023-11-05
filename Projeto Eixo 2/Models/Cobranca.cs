using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Eixo_2.Models
{
    [Table("Cobranças")]
    public class Cobranca
    {
        [Key]
        public int Id { get; set; }

        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        [Required(ErrorMessage = "Obrigatório informar o cliente.")]
        public Cliente Cliente { get; set; }
    }
}
