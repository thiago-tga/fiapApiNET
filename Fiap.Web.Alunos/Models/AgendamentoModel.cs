using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.Alunos.Models
{
    public class AgendamentoModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("agendamento_id")]
        public long Id { get; set; }

        public string Endereco { get; set; }

        public DateTime Data { get; set; }

        [Required]
        public string Cliente { get; set; }

        [Required]
        [Column("status")]
        public StatusColeta StatusColeta { get; set; }
    }

    public enum StatusColeta
    {
        Coletado,
        Agendado
    }

}
