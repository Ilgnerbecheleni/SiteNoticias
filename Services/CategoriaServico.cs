using Microsoft.AspNetCore.Mvc;
using SiteNoticias.DTOS.Categoria;
using SiteNoticias.Models;
using SiteNoticias.Repositorios;

namespace SiteNoticias.Services;

public class CategoriaServico
{
    

    //campo injetado no construtor

    private CategoriaRepositorio _categoriaRepositorio ;

    // construtor com injeção de dependencia

    public CategoriaServico ([FromServices]CategoriaRepositorio repositorio ){

        _categoriaRepositorio = repositorio ;

    }

public CategoriaResposta CriarCategoria(CategoriaCriarAtualizar novaCategoria){

//copiar dados para o modelo

var categoria = new Categoria ();
ConverterRequisicaoParaModelo(novaCategoria,categoria);
//envia categoria para salva no BD
categoria = _categoriaRepositorio.CriarCategoria(categoria);
//copiar do modelo 
var categoriaResposta = ConverterModeloParaResposta(categoria);
return categoriaResposta ;
}

public List<CategoriaResposta> ListarCategorias(){
//pedir lista de categorias
var categorias = _categoriaRepositorio.ListarCategorias();
//criar lista resposta
List<CategoriaResposta> categoriaRespostas = new ();
//copiar dados
foreach(var categoria in categorias){
// opiar modelo para resposta
var cateoriResposta = ConverterModeloParaResposta(categoria);
//add resposta
categoriaRespostas.Add(cateoriResposta);

}


return categoriaRespostas ;


}


private CategoriaResposta ConverterModeloParaResposta (Categoria modelo){
var categoriaResposta = new CategoriaResposta ();
categoriaResposta.Id = modelo.Id ;
categoriaResposta.Nome = modelo.Nome ;

return categoriaResposta ;

}

public CategoriaResposta BuscarCategoriaPeloID(int id){

/// pedir categoria do respositorio

var categoria = _categoriaRepositorio.BuscarCategoriaPeloID(id);
if(categoria is null){
    return null ; //vai ser excessão
}
//copiar do modelo para resposta

var categoriaResposta = ConverterModeloParaResposta(categoria);


return categoriaResposta;


}


public void RemoverCategoria(int id){

//buscar categoria pelo id
var categoria = _categoriaRepositorio.BuscarCategoriaPeloID(id);

if(categoria is null){
    return  ;  // depois trata 
}

//mandar remover
_categoriaRepositorio.RemoverCategoria(categoria);

}

public CategoriaResposta AtualizarCategoria(int id , CategoriaCriarAtualizar categoriaEditada){

    //buscar modelo
var categoria = _categoriaRepositorio.BuscarCategoriaPeloID(id);

if(categoria is null){
    return null; // depois
}



//copiar da requisicao
ConverterRequisicaoParaModelo(categoriaEditada,categoria);


//mandar para o respositorio salvar

_categoriaRepositorio.AtualizarCategoria();

return ConverterModeloParaResposta(categoria);


}

private void ConverterRequisicaoParaModelo (CategoriaCriarAtualizar requisicao,Categoria modelo ){

modelo.Nome = requisicao.Nome ;



}



}



