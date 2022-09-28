using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteNoticias.Models
{
    public class Categoria
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nome { get; set; }

        public Noticia Noticia { get; set; }


    }
}