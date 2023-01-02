using Microsoft.AspNetCore.Mvc;
using SiteNoticias.Data;
using SiteNoticias.Models;

namespace SiteNoticias.Repositorios;

public class PerfilRepositorio
{


//campo que vai ser injetdao

private ContextoBD _contexto;

// construtor que injeta a dependencia

public PerfilRepositorio ([FromServices] ContextoBD contexto){

_contexto = contexto ;
    

}





   public Perfil CriarPefil(Perfil perfil){

// manda contexto salvar no BD
_contexto.Perfis.Add(perfil);

_contexto.SaveChanges();

//vai retornar o ID tambem
return perfil;



    }



public List<Perfil> ListarPerfis(){

return _contexto.Perfis.ToList();

}


public Perfil buscarPerfilPeloId( int id){
 //buscar pelo id

 return _contexto.Perfis.FirstOrDefault(perfil => perfil.Id == id);



}

public void RemoverPerfil(Perfil perfil){

//mandar contexto remover

_contexto.Remove(perfil);

_contexto.SaveChanges();


}


public void AtualizarPerfil(){

_contexto.SaveChanges();


}


}
