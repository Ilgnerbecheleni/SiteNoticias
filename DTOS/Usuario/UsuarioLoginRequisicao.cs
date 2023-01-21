using System.ComponentModel.DataAnnotations;

namespace SiteNoticias.DTOS.Usuario;

public class UsuarioLoginRequisicao
{
    [Required]
    [StringLength(50)]
    public string Email { get; set; }
    [Required]
    [StringLength(70)]
    public string Senha { get; set; }


}
