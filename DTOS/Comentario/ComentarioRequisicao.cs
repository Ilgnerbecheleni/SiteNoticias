namespace SiteNoticias.DTOS.Comentario;

public class ComentarioRequisicao
{
    public int Id { get; set; }


    public string Conteudo { get; set; }

    public DateTime DataComentario { get; set; }

    public int Usuario { get; set; }

    public int Noticia { get; set; }



}
