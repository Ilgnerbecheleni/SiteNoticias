using Microsoft.EntityFrameworkCore;
using SiteNoticias.Models;

namespace SiteNoticias.Data
{
    public class ContextoBD : DbContext
    {

        public ContextoBD(DbContextOptions<ContextoBD> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }



    }
}