

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SiteNoticias.DTOS.Usuario;

public class UsuarioResposta
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Email { get; set; }

    public UserPerfilResposta Perfil { get; set; }

   



}

public class UserPerfilResposta
{
    public int Id { get; set; }
    public string Nome { get; set; }
}
