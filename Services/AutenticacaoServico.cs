using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SiteNoticias.DTOS.Usuario;
using SiteNoticias.Models;
using SiteNoticias.Repositorios;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SiteNoticias.Services;

public class AutenticacaoServico
{
    private readonly UsuarioRepositorio _usuarioRepositorio;

    private readonly IConfiguration _configuration;

    public AutenticacaoServico([FromServices] UsuarioRepositorio repositorio, [FromServices] IConfiguration configuration)
    {
        _usuarioRepositorio = repositorio;
        _configuration = configuration;
    }

    public string Login(UsuarioLoginRequisicao usuarioLogin)
    {
        var usuario = _usuarioRepositorio.BuscarUsuarioPeloEmail(usuarioLogin.Email);



        if ((usuario is null) || (!BCrypt.Net.BCrypt.Verify(usuarioLogin.Senha, usuario.Senha)))
        {
            throw new Exception("Usuario ou senha incorretos");
        }

      
        var tokenJWT = GerarJWT(usuario);
        return tokenJWT;

    }

    private string GerarJWT(Usuario usuario)
    {
        //Pegando a chave JWT
        var JWTChave = Encoding.ASCII.GetBytes(_configuration["JWTChave"]);

        //Criando as credenciais
        var credenciais = new SigningCredentials(
                new SymmetricSecurityKey(JWTChave),
                SecurityAlgorithms.HmacSha256);

        //CLAIMS informacoes sobre o usuario ou sobre o token
        var claims = new List<Claim>();

        //Nome do usuario
        claims.Add(new Claim(ClaimTypes.Name, usuario.Nome));

        //Id do usuario
        claims.Add(new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()));

        //Perfil do usuario
        claims.Add(new Claim(ClaimTypes.Role, usuario.Perfil.Nome));

      

        //Criando o token
        var tokenJWT = new JwtSecurityToken(
            expires: DateTime.Now.AddHours(8),
            signingCredentials: credenciais,
            claims: claims
        );

        //Escrevendo o token e retornando
        return new JwtSecurityTokenHandler().WriteToken(tokenJWT);
    }


}
