namespace SiteNoticias.DTOS.Noticia;

public class NoticiaRequisicao
{
    public int Id { get; set; }

    public string Titulo { get; set; }

    public string Imagem { get; set; }

    public string Conteudo { get; set; }

    public DateTime DataPublicacao { get; set; }

    public int Curtida { get; set; }

    public int View { get; set; }

    public int Usuario { get; set; }

    public int Categoria { get; set;}



}
