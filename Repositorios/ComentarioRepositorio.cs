using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteNoticias.Data;
using SiteNoticias.Models;

namespace SiteNoticias.Repositorios;

public class ComentarioRepositorio
{
    private readonly ContextoBD _contexto;

    public ComentarioRepositorio([FromServices] ContextoBD contexto)
    {
        _contexto = contexto;
    }

    public Comentario CriarComentario(Comentario comentario)
    {
        _contexto.Add(comentario);
        _contexto.SaveChanges();

        return comentario;
    }

    public List<Comentario> ListarComentarios()
    {
        return _contexto.Comentarios
          .Include(comentario => comentario.Usuario)
          .Include(comentario => comentario.Noticia)
          .AsNoTracking().ToList();
    }

    public Comentario BuscarComentarioPeloId(int id, bool tracking = true)
    {
        return tracking ?
          _contexto.Comentarios.Include(comentario => comentario.Usuario).Include(comentario => comentario.Noticia).FirstOrDefault(u => u.Id == id) :
          _contexto.Comentarios.AsNoTracking().Include(comentario => comentario.Usuario).Include(comentario => comentario.Noticia).FirstOrDefault(u => u.Id == id);
    }

    public void RemoverComentario(Comentario comentario)
    {
        _contexto.Remove(comentario);
        _contexto.SaveChanges();
    }

    public void AtualizarComentario()
    {

        _contexto.SaveChanges();



    }





}
