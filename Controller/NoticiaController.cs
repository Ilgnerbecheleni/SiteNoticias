using Microsoft.AspNetCore.Mvc;
using SiteNoticias.DTOS.Noticia;
using SiteNoticias.DTOS.Usuario;
using SiteNoticias.Excecoes;
using SiteNoticias.Services;

namespace SiteNoticias.Controller;


[ApiController]
[Route("noticias")]
public class NoticiaController:ControllerBase
{


    private readonly NoticiaServico _noticiaServico;


    public NoticiaController([FromServices] NoticiaServico servico)
    {
        _noticiaServico = servico;
    }


    [HttpPost]
    public ActionResult<NoticiaResposta> PostNoticia(NoticiaRequisicao novaNoticia)
    {
        try
        {
            var noticiaResposta = _noticiaServico.CriarNoticia(novaNoticia);

            return StatusCode(201, noticiaResposta);
        }
        catch (BadHttpRequestException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public ActionResult<List<NoticiaResposta>> GetNoticias()
    {
        return Ok(_noticiaServico.ListarNoticias());
    }

    [HttpGet("{id:int}")]
    public ActionResult<NoticiaResposta> GetNoticiasPeloId([FromRoute] int id)
    {
        try
        {
            return Ok(_noticiaServico.BuscarNoticiaPeloId(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteNoticia([FromRoute] int id)
    {
        try
        {
            _noticiaServico.RemoverNoticia(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<NoticiaResposta>
      PutNoticia([FromRoute] int id, [FromBody] NoticiaCriarAtualizarRequisicao noticiaEditada)
    {
        try
        {
            return Ok(_noticiaServico.AtualizarNoticia(id, noticiaEditada));
        }
         catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

  




















}
