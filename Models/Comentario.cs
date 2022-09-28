using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteNoticias.Models
{
    public class Comentario
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Conteudo { get; set; }

        public Usuario Usuario { get; set; }

        public int UsuarioId { get; set; }

        public Noticia Noticia { get; set; }

        public int NoticiaId { get; set; }

    }
}