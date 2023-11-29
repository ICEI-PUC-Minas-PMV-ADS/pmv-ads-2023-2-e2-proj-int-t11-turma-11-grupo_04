using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Eixo_2.Models
{
    [Table("Cobranca")]
    public class Cobranca
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Data de cobrança")]
        [Required(ErrorMessage = "É obrigatório inserir uma data para a cobrança.")]
        public DateTime Data { get; set; }

        [Display(Name = "Data de Vencimento")]
        [Required(ErrorMessage = "É obrigatório inserir uma data de vencimento.")]
        public DateTime Vencimento { get; set; }


        [Display(Name = "Data de pagamento")]
        public DateTime? Pagamento { get; set; }

        [Display(Name = "Status da cobrança")]
        public int CodigoStatus { get; set; }
        public string StatusCobranca { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "É obrigatório informar o valor.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o cliente.")]
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [ForeignKey("CobradorId")]
        [Required(ErrorMessage = "É obrigatório informar o cobrador.")]
        public int CobradorId { get; set; }
        public Cobrador Cobrador { get; set; }
    }

    public enum StatusCobranca
    {
        Pendente,
        Pago,
        Vencido
    }
}
