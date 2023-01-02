
namespace SiteNoticias.DTOS.Noticia;

public class NoticiaResposta
{
    
    public int Id { get; set; }
   
    public string Titulo { get; set; }

   public string Imagem { get; set; }
        
   public string Conteudo { get; set; }

    public DateTime DataPublicacao { get; set; }

    public int Curtida { get; set; }

    public int View { get; set; }

    public NoticiaCategoria Categoria { get; set; }

    public UsuarioNoticia Usuario { get; set; }

}
public class NoticiaCategoria
{
    public int Id { get; set; }
    public string Nome { get; set;}
}


public class UsuarioNoticia
{
    public int Id { get; set; }
    public string Nome { get; set;}
}
