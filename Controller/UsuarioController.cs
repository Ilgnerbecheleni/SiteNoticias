using Microsoft.AspNetCore.Mvc;
using SiteNoticias.DTOS.Comentario;
using SiteNoticias.DTOS.Usuario;
using SiteNoticias.Excecoes;
using SiteNoticias.Services;

namespace SiteNoticias.Controller;

[ApiController]
[Route("usuarios")]
public class UsuarioController:ControllerBase
{

    private readonly UsuarioServico _usuarioServico;


    public UsuarioController([FromServices] UsuarioServico servico)
    {
        _usuarioServico= servico;
    }


    [HttpPost]
    public ActionResult<UsuarioResposta> PostUsuario(UsuarioRequisicao novoUsuario)
    {
        try
        {
            var usuarioResposta = _usuarioServico.CriarUsuario(novoUsuario);
            
            return StatusCode(201, usuarioResposta);
        }
        catch (BadHttpRequestException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public ActionResult<List<UsuarioResposta>> GetUsuarios()
    {
        return Ok(_usuarioServico.ListarUsuarios());
    }

    [HttpGet("{id:int}")]
    public ActionResult<UsuarioResposta> GetUsuario([FromRoute] int id)
    {
        try
        {
            return Ok(_usuarioServico.BuscarUsuarioPeloId(id));
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
            _usuarioServico.RemoverUsuario(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<UsuarioResposta>
      PutUsuario([FromRoute] int id, [FromBody] UsuarioCriarAtualizar usuarioEditado)
    {
        try
        {
            return Ok(_usuarioServico.AtualizarUsuario(id, usuarioEditado));
        }
        catch (EmailException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

   


}
