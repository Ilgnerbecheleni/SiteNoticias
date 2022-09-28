using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteNoticias.Models
{
    public class Usuario
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Nome { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Senha { get; set; }

        public Perfil Perfil { get; set; }

        public int PerfilId { get; set; }

        public List<Noticia> Noticias { get; set; }
        public int NoticiasId { get; set; }

        public List<Comentario> Comentarios { get; set; }





    }
}