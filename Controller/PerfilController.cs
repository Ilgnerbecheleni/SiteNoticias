using Microsoft.AspNetCore.Mvc;
using SiteNoticias.DTOS.Perfil;
using SiteNoticias.Services;

namespace SiteNoticias.Controller
{
    [ApiController]
    [Route("perfil")]
    public class PerfilController : ControllerBase
    {

   //injetando no construtor
        private PerfilServico _perfilServico ;

        //construtor com injeção de dependencia

        public PerfilController ([FromServices]  PerfilServico servico ){
          
        _perfilServico = servico;




        }
 

[HttpPost]
public PerfilResposta postPerfil ([FromBody] PerfilCriarAtualizar novoPerfil ){

// envia serviço


var perfilResposta =  _perfilServico.CriarPefil(novoPerfil);

//retornando resposta
return perfilResposta;


}

[HttpGet]

public List<PerfilResposta> GetPerfil (){

    return _perfilServico.ListarPerfis();
}



[HttpGet("{id:int}")]
public PerfilResposta GetPerfil([FromRoute] int id){


return _perfilServico.BuscarPerfilPeloId(id);

}

[HttpDelete("{id:int}")]
public void DeletePertfil([FromRoute]int id){

//manda o serviço remover
_perfilServico.RemoverPerfil(id);

}

[HttpPut("{id:int}")]
public PerfilResposta PutPerfil([FromRoute]int id ,[FromBody] PerfilCriarAtualizar perfilEditado){

return _perfilServico.AtualizarPerfil(id,perfilEditado);

}

    }
}