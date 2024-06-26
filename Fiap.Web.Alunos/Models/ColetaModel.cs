using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.Alunos.Models
{
    public class ColetaModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("coleta_id")]
        public long Id { get; set; }

        [Column("name_item")]
        public string NameItem { get; set; }

        [Column("qnt_item")]
        public decimal QntItem { get; set; }

        public string Material { get; set; }
    }
}
