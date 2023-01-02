using Microsoft.AspNetCore.Mvc;
using SiteNoticias.DTOS.Comentario;
using SiteNoticias.DTOS.Usuario;
using SiteNoticias.Excecoes;
using SiteNoticias.Services;

namespace SiteNoticias.Controller;

[ApiController]
[Route("comentarios")]
public class ComentarioController : ControllerBase
{


    private readonly ComentarioServico _comentarioServico;


    public ComentarioController([FromServices] ComentarioServico comentario)
    {
        _comentarioServico = comentario;
    }


    [HttpPost]
    public ActionResult<ComentarioResposta> PostComentario(ComentarioRequisicao novoComentario)
    {
        try
        {
            var comentarioResposta = _comentarioServico.CriarComentario(novoComentario);

            return StatusCode(201, comentarioResposta);
        }
        catch (BadHttpRequestException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public ActionResult<List<ComentarioResposta>> GetComentarios()
    {
        return Ok(_comentarioServico.ListarComentarios());
    }

    [HttpGet("{id:int}")]
    public ActionResult<UsuarioResposta> GetComentario([FromRoute] int id)
    {
        try
        {
            return Ok(_comentarioServico.BuscarComentarioPeloId(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteUsuario([FromRoute] int id)
    {
        try
        {
            _comentarioServico.RemoverComentario(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<ComentarioResposta>
      PutUsuario([FromRoute] int id, [FromBody] ComentarioCriarAtualizar comentarioeditado)
    {
        try
        {
            return Ok(_comentarioServico.AtualizarComentario(id, comentarioeditado));
        }
          catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }




}
