using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace SiteNoticias.Models;
[Index(nameof(Email), IsUnique = true)]
public class Usuario
{
    [Required]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Nome { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Email { get; set; }

    [Required]
    [Column(TypeName = "varchar(70)")]
    public string Senha { get; set; }

    public Perfil Perfil { get; set; }
    

    public List<Noticia> Noticias { get; set; }


    public List<Comentario> Comentarios { get; set; }

}