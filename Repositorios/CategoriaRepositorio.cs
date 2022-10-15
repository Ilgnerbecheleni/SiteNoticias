using Microsoft.AspNetCore.Mvc;
using SiteNoticias.Data;
using SiteNoticias.Models;

namespace SiteNoticias.Repositorios;

public class CategoriaRepositorio
{
    
//campo injetado no construtor

private ContextoBD _contexto ;

//construtor que injeta dependencia

public CategoriaRepositorio ([FromServices]ContextoBD contexto  ){

_contexto = contexto;

}

public Categoria CriarCategoria(Categoria categoria)
{

//manda contexto salva no BD

_contexto.Categorias.Add(categoria);
_contexto.SaveChanges();


//vai estar preenchido com a chave primaria
return categoria ;

}


public List<Categoria> ListarCategorias(){

return _contexto.Categorias.ToList();


}


public Categoria BuscarCategoriaPeloID (int id)
{

//buscar pelo ID

return _contexto.Categorias.FirstOrDefault(categoria=> categoria.Id == id);

}

public void RemoverCategoria (Categoria categoria){

//mandar contexto remover

_contexto.Remove(categoria);

_contexto.SaveChanges();

}


public void AtualizarCategoria (){

_contexto.SaveChanges();



}


}
