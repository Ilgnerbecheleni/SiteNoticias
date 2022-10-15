using Microsoft.AspNetCore.Mvc;
using SiteNoticias.DTOS.Categoria;
using SiteNoticias.Services;

namespace SiteNoticias.Controller;

[ApiController]
[Route("categoria")]
public class CategoriaController:ControllerBase
{


// injetando no construtor
    private CategoriaServico _categoriaServico ;

//construtor com injeção de dependencia 
    public CategoriaController ([FromServices] CategoriaServico servico){

         _categoriaServico = servico ;

    }
    
[HttpPost]


public CategoriaResposta PostCategoria([FromBody] CategoriaCriarAtualizar novaCategoria)
{



//enviar para servico

var categoriaResposta = _categoriaServico.CriarCategoria(novaCategoria);

return categoriaResposta ;


}

[HttpGet]
public List<CategoriaResposta> GetCategorias()
{

//pedir retorno a lista

return _categoriaServico.ListarCategorias();

}

[HttpGet("{id:int}")]

public CategoriaResposta GetCategoria([FromRoute]int id){

//buscando e retornando

return _categoriaServico.BuscarCategoriaPeloID(id);

}

[HttpDelete("{id:int}")]

public void DeleteCategoria([FromRoute] int id){
    //manda o serviço
_categoriaServico.RemoverCategoria(id);

}

[HttpPut("{id:int}")]

public CategoriaResposta PutCategoria([FromRoute]int id,[FromBody] CategoriaCriarAtualizar categoriaEditada){

return _categoriaServico.AtualizarCategoria(id,categoriaEditada);


}


}
