using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjMaster.Models
{
    public class Lanche
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Genero { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Preco { get; set; }

        [StringLength(200)]
        public string ImagemUrl { get; set; }

        [StringLength(200)]
        public string ImagemThumbnailUrl { get; set; }

    }
}