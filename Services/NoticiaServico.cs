using Mapster;
using Microsoft.AspNetCore.Mvc;
using SiteNoticias.DTOS.Noticia;
using SiteNoticias.DTOS.Usuario;
using SiteNoticias.Excecoes;
using SiteNoticias.Models;
using SiteNoticias.Repositorios;

namespace SiteNoticias.Services;

public class NoticiaServico
{
    private readonly NoticiaRepositorio _noticiaRepositorio;
    private readonly UsuarioRepositorio _usuarioRepositorio;
    private readonly CategoriaRepositorio _categoriaRepositorio;


    public NoticiaServico
    ([FromServices] NoticiaRepositorio notrepositorio, [FromServices] UsuarioRepositorio userRepositorio, [FromServices] CategoriaRepositorio catRepositorio)
    {
        _noticiaRepositorio = notrepositorio;
        _usuarioRepositorio = userRepositorio;
        _categoriaRepositorio = catRepositorio;
    }

    public NoticiaResposta CriarNoticia(NoticiaRequisicao novaNoticia)
    {



        //------------busca categoria

        int idCategoria = novaNoticia.Categoria;
        var categoriabusca = _categoriaRepositorio.BuscarCategoriaPeloID(idCategoria);

        if (categoriabusca is null)
        {
            throw new BadHttpRequestException("Categoria não Existente");
        }

        int idUsuario = novaNoticia.Usuario;

        //---- busca usuario e atribui ao campo
        var usuarioBusca = _usuarioRepositorio.BuscarUsuarioPeloId(idUsuario);

        if (usuarioBusca is null)
        {
            throw new BadHttpRequestException("Usuario não Existente");
        }

        //--- atribuir Data
        DateTime dataAtual = DateTime.Now;





        //copiar da requisicao para o modelo
        var noticia = novaNoticia.Adapt<Noticia>();


        noticia.DataPublicacao= dataAtual;
        noticia.Categoria = categoriabusca;
        noticia.Usuario = usuarioBusca;
        //Mando o respositorio salvar
        noticia = _noticiaRepositorio.CriarNoticia(noticia);

        //Copia do modelo pra resposta
        var noticiaResposta = noticia.Adapt<NoticiaResposta>();

        return noticiaResposta;
    }

    public List<NoticiaResposta> ListarNoticias()
    {
        return _noticiaRepositorio.ListarNoticias().Adapt<List<NoticiaResposta>>();
    }

    public NoticiaResposta BuscarNoticiaPeloId(int id)
    {
       
        return BuscarNotPeloId(id).Adapt<NoticiaResposta>();
    }

    private Noticia BuscarNotPeloId(int id, bool tracking = true)
    {
       
        var noticia = _noticiaRepositorio.BuscarNoticiaPeloId(id, tracking);

        
        
        if (noticia is null)
        {
            throw new Exception("Noticia não encontrada");
        }

       


        return noticia;
    }

    public void RemoverNoticia(int id)
    {
        var noticia = BuscarNotPeloId(id);

        _noticiaRepositorio.RemoverNoticia(noticia);
    }

    public NoticiaResposta AtualizarNoticia(int id, NoticiaCriarAtualizarRequisicao noticiaEditada)
    {

        var noticia = BuscarNotPeloId(id);

        //------------busca categoria

        int idCategoria = noticiaEditada.Categoria;
        var categoriabusca = _categoriaRepositorio.BuscarCategoriaPeloID(idCategoria);

        if (categoriabusca is null)
        {
            throw new BadHttpRequestException("Categoria não Existente");
        }

        int idUsuario = noticiaEditada.Usuario;

        //---- busca usuario e atribui ao campo
        var usuarioBusca = _usuarioRepositorio.BuscarUsuarioPeloId(idUsuario);

        if (usuarioBusca is null)
        {
            throw new BadHttpRequestException("Usuario não Existente");
        }

        DateTime dataAtual = DateTime.Now;

        //Copiar os dados da requisicao pro modelo
        noticiaEditada.Adapt(noticia);

        noticia.DataPublicacao = dataAtual.Date;
        noticia.Categoria = categoriabusca;
        noticia.Usuario = usuarioBusca;

        //Salvar no repositorio
        _noticiaRepositorio.AtualizarNoticia();

        //Copiar do modelo para a resposta
        var noticiaResposta = noticia.Adapt<NoticiaResposta>();

        return noticiaResposta;

    }

   public NoticiaResposta AdicionarCurtida(int noticiaId)
    {

        var noticia = BuscarNotPeloId(noticiaId);
        if (noticia is null)
        {
            throw new BadHttpRequestException("Noticia Não encontrada");
        }
        noticia.Curtida++;

        _noticiaRepositorio.AtualizarNoticia();

        _noticiaRepositorio.AtualizarNoticia();

        //Copiar do modelo para a resposta
        var noticiaResposta = noticia.Adapt<NoticiaResposta>();

        return noticiaResposta;

    }

    public NoticiaResposta AdicionarView(int noticiaId)
    {

        var noticia = BuscarNotPeloId(noticiaId);
        if (noticia is null)
        {
            throw new BadHttpRequestException("Noticia Não encontrada");
        }
        noticia.View++;

        _noticiaRepositorio.AtualizarNoticia();

        _noticiaRepositorio.AtualizarNoticia();

        //Copiar do modelo para a resposta
        var noticiaResposta = noticia.Adapt<NoticiaResposta>();

        return noticiaResposta;

    }






}
