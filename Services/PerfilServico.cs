using Microsoft.AspNetCore.Mvc;
using SiteNoticias.DTOS.Perfil;
using SiteNoticias.Models;
using SiteNoticias.Repositorios;

namespace SiteNoticias.Services;



public class PerfilServico
{
   //campo injetado no construtor

   private PerfilRepositorio _perfilRepoitorio;

   //construtor com injeçao de dependencia

   public PerfilServico ([FromServices] PerfilRepositorio repositorio ){

    _perfilRepoitorio = repositorio ;



   }

public PerfilResposta CriarPefil (PerfilCriarAtualizar novoPerfil ){
    
//copiar dados da requisicao


var perfil = new Perfil ();



ConverterRequisicaoParaModelo(novoPerfil,perfil);
       //enviar procedimento

perfil= _perfilRepoitorio.CriarPefil(perfil);

//copiar do modelo para resposta

var perfilResposta = ConverterModeloParaRespota(perfil);


//retornar a resposta


return perfilResposta;


}

public List<PerfilResposta> ListarPerfis (){

// pedir lista de procedimento

var perfis = _perfilRepoitorio.ListarPerfis();
//criar lista de resposta

List<PerfilResposta> perfilRespostas = new ();

//copiar dados modelo para resposta


foreach (var perfil in perfis)
{

var perfilResposta = ConverterModeloParaRespota(perfil);

//adicionar resposta na lsita

perfilRespostas.Add(perfilResposta);



    
}

return perfilRespostas ;

}


private PerfilResposta ConverterModeloParaRespota(Perfil modelo){
    

var perfilResposta = new PerfilResposta ();

perfilResposta.Id = modelo.Id;
perfilResposta.Nome = modelo.Nome;

return perfilResposta ;

}

public PerfilResposta BuscarPerfilPeloId(int id){
    //pedir perfil para repositorio

    var perfil = _perfilRepoitorio.buscarPerfilPeloId(id) ;


if(perfil is null){
return null ;  //futuro sera excessão
}
    //copiar modelo para resposta
    var perfilResposta = ConverterModeloParaRespota(perfil);

    //retornando respsota

    return perfilResposta ;

}

public void RemoverPerfil(int id){

//buscar pelo id

var perfil = _perfilRepoitorio.buscarPerfilPeloId(id);

if(perfil is null){
    return ; // tratar com exception
}

//mandqar repositorio remover modelo

_perfilRepoitorio.RemoverPerfil(perfil);


}

public PerfilResposta AtualizarPerfil(int id ,PerfilCriarAtualizar perfilEditado){
    
// buscar modelo no repositorio
var perfil = _perfilRepoitorio.buscarPerfilPeloId(id);

if(perfil is null){
    return null ; //tratamento depois
}

//copiar requisicao

ConverterRequisicaoParaModelo(perfilEditado,perfil);

//mandar repositorio salvar

_perfilRepoitorio.AtualizarPerfil();

//copiar modelo para respostA

return ConverterModeloParaRespota(perfil);


}
    
private void ConverterRequisicaoParaModelo (PerfilCriarAtualizar requisicao , Perfil modelo){

modelo.Nome = requisicao.Nome ;


}

}
