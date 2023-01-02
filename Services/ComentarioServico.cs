using Mapster;
using Microsoft.AspNetCore.Mvc;
using SiteNoticias.DTOS.Comentario;
using SiteNoticias.DTOS.Noticia;
using SiteNoticias.DTOS.Usuario;
using SiteNoticias.Excecoes;
using SiteNoticias.Models;
using SiteNoticias.Repositorios;

namespace SiteNoticias.Services;

public class ComentarioServico
{
    private readonly NoticiaRepositorio _noticiaRepositorio;
    private readonly UsuarioRepositorio _usuarioRepositorio;
    private readonly ComentarioRepositorio _comentarioRepositorio;


    public ComentarioServico
    ([FromServices] NoticiaRepositorio notrepositorio, [FromServices] UsuarioRepositorio userRepositorio, [FromServices] ComentarioRepositorio comRepositorio)
    {
        _noticiaRepositorio = notrepositorio;
        _usuarioRepositorio = userRepositorio;
        _comentarioRepositorio = comRepositorio;
    }

    public ComentarioResposta CriarComentario(ComentarioRequisicao novoComentario)
    {

     

        int idusuario = novoComentario.Usuario;
        Console.WriteLine(idusuario);
        var usuarioBusca = _usuarioRepositorio.BuscarUsuarioPeloId(idusuario);

        if (usuarioBusca is null)
        {
            throw new BadHttpRequestException("Usuario não Existente");
        }



        int idNoticia = novoComentario.Noticia;

        //---- busca usuario e atribui ao campo
        var noticiaBusca = _noticiaRepositorio.BuscarNoticiaPeloId(idNoticia);

        if (noticiaBusca is null)
        {
            throw new BadHttpRequestException("Usuario não Existente");
        }

        //--- atribuir Data
        DateTime dataAtual = DateTime.Now;





        //copiar da requisicao para o modelo
        var comentarioA = novoComentario.Adapt<Comentario>();


        comentarioA.DataComentario = dataAtual;
        comentarioA.Usuario = usuarioBusca;
        comentarioA.Noticia = noticiaBusca;
        //Mando o respositorio salvar
        comentarioA = _comentarioRepositorio.CriarComentario(comentarioA);

        //Copia do modelo pra resposta
        var comentarioResposta = comentarioA.Adapt<ComentarioResposta>();

        return comentarioResposta;
    }






    public List<ComentarioResposta> ListarComentarios()
    {
        return _comentarioRepositorio.ListarComentarios().Adapt<List<ComentarioResposta>>();
    }

    public ComentarioResposta BuscarComentarioPeloId(int id)
    {
        return BuscarComentarioPeloId(id).Adapt<ComentarioResposta>();
    }

    private Comentario BuscarPeloId(int id, bool tracking = true)
    {
        var comentario = _comentarioRepositorio.BuscarComentarioPeloId(id, tracking);

        if (comentario is null)
        {
            throw new Exception("Comentario não encontrado");
        }

        return comentario;
    }

    public void RemoverComentario(int id)
    {
        var comentario = BuscarPeloId(id);

        _comentarioRepositorio.RemoverComentario(comentario);
    }

    public ComentarioResposta AtualizarComentario(int id, ComentarioCriarAtualizar comentarioEditado)
    {

        var comentario = BuscarPeloId(id);





        //Copiar os dados da requisicao pro modelo
        comentarioEditado.Adapt(comentario);


        //Salvar no repositorio
        _comentarioRepositorio.AtualizarComentario();

        //Copiar do modelo para a resposta
        var comentarioResposta = comentario.Adapt<ComentarioResposta>();

        return comentarioResposta;

    }






}
