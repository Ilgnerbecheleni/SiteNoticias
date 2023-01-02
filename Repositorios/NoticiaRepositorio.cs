using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteNoticias.Data;
using SiteNoticias.Models;

namespace SiteNoticias.Repositorios;

public class NoticiaRepositorio
{
    private readonly ContextoBD _contexto;

    public NoticiaRepositorio([FromServices] ContextoBD contexto)
    {
        _contexto = contexto;
    }

    public Noticia CriarNoticia(Noticia noticia)
    {
        _contexto.Add(noticia);
        _contexto.SaveChanges();

        return noticia;
    }

       public List<Noticia> ListarNoticias()
    {
        return _contexto.Noticias
          .Include(noticia => noticia.Categoria)
          .Include(noticia => noticia.Usuario)
          .AsNoTracking().ToList();
    }

    public Noticia BuscarNoticiaPeloId(int id, bool tracking = true)
    {
        return tracking ?
          _contexto.Noticias.Include(noticia => noticia.Usuario).Include(noticia => noticia.Categoria).FirstOrDefault(u => u.Id == id) :
          _contexto.Noticias.AsNoTracking().Include(noticia => noticia.Usuario).Include(noticia => noticia.Categoria).FirstOrDefault(u => u.Id == id);
    }

    public void RemoverNoticia(Noticia noticia)
    {
        _contexto.Remove(noticia);
        _contexto.SaveChanges();
    }

    public void AtualizarNoticia()
    {
        _contexto.SaveChanges();
    }
}
