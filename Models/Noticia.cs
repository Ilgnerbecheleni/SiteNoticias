using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteNoticias.Models
{
    public class Noticia
    {

        [Required]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "Varchar(100)")]
        public string Titulo { get; set; }

        [Required]
        [Column(TypeName = "Varchar(300)")]
        public string Imagem { get; set; }

        [Required]
        [Column(TypeName = "Text")]
        public string Conteudo { get; set; }

        [Required]

        public DateTime DataPublicacao { get; set; }

        public int Curtida { get; set; }

        public int View { get; set; }

        public List<Comentario> Comentarios { get; set; }

        public Usuario Usuario { get; set; }

        public int UsuarioId { get; set; }


        public Categoria Categoria { get; set; }

        public int CategoriaId { get; set; }

    }
}