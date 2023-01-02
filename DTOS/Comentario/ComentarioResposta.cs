

using SiteNoticias.DTOS.Noticia;
using SiteNoticias.DTOS.Usuario;

namespace SiteNoticias.DTOS.Comentario;

public class ComentarioResposta
{
   
    public int Id { get; set; }

    
    public string Conteudo { get; set; }
  
    public DateTime DataComentario { get; set; }

    public UsuarioComentario Usuario { get; set; }

    public NoticiaComentario Noticia { get; set; }


}


public class UsuarioComentario
{
    public int Id { get; set; }

    public string Nome { get; set; }

  
}


public class NoticiaComentario
{
    public int Id { get; set; }
    public string Titulo { get; set; }
}
