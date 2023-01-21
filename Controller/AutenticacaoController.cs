using Microsoft.AspNetCore.Mvc;
using SiteNoticias.DTOS.Usuario;
using SiteNoticias.Services;

namespace SiteNoticias.Controller;
[ApiController]
[Route("[controller]")]
public class AutenticacaoController:ControllerBase
{
    private readonly AutenticacaoServico _autenticacaoServico;

    public AutenticacaoController([FromServices] AutenticacaoServico servico)
    {
        _autenticacaoServico= servico;

    }

    [HttpPost]

    public ActionResult <string> Login([FromBody] UsuarioLoginRequisicao usuariologin)
    {
        try
        {
            var tokenJWT = _autenticacaoServico.Login(usuariologin);
            return Ok(tokenJWT);
        }catch(Exception e)
        {
            return NotFound(e.Message);
        }


    }



}
