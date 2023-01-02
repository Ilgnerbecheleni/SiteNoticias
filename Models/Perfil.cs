using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteNoticias.Models
{
    public class Perfil
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Nome { get; set; }
       

        public List<Usuario> Usuarios { get; set; }


    }
}