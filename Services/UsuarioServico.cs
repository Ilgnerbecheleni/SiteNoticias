using Microsoft.AspNetCore.Mvc;
using SiteNoticias.DTOS.Usuario;
using SiteNoticias.Models;
using SiteNoticias.Repositorios;
using Mapster;
using SiteNoticias.Excecoes;


namespace SiteNoticias.Services;

public class UsuarioServico
{
    private readonly UsuarioRepositorio _usuarioRepositorio;
    private readonly PerfilRepositorio _perfilRepositorio;


    public UsuarioServico
    ([FromServices] UsuarioRepositorio repositorio, [FromServices] PerfilRepositorio pRepositorio)
    {
        _usuarioRepositorio = repositorio;
        _perfilRepositorio = pRepositorio;

    }

    public UsuarioResposta CriarUsuario(UsuarioRequisicao novoUsuario)
    {
        //Verificar se já existe usuario com aquela senha
        var usuarioExistente = _usuarioRepositorio.BuscarUsuarioPeloEmail(novoUsuario.Email);
        if (usuarioExistente is not null)
        {
            throw new BadHttpRequestException("Já existe um usuário com esse email");
        }


        //-------------------
        int idPerfil = novoUsuario.Perfil;


        var perfilbusca = _perfilRepositorio.buscarPerfilPeloId(idPerfil);

        if (perfilbusca is null)
        {
            throw new BadHttpRequestException("Perfil não Existente");
        }

       
        //copiar da requisicao para o modelo
        var usuario = novoUsuario.Adapt<Usuario>();

        //Criptografando a senha
        usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);

        usuario.Perfil = perfilbusca;
        //Mando o respositorio salvar
        usuario = _usuarioRepositorio.CriarUsuario(usuario);
        
        //Copia do modelo pra resposta
        var usuarioResposta = usuario.Adapt<UsuarioResposta>();
      
        return usuarioResposta;
    }

    public List<UsuarioResposta> ListarUsuarios()
    {
        return _usuarioRepositorio.ListarUsuarios().Adapt<List<UsuarioResposta>>();
    }




    public UsuarioResposta BuscarUsuarioPeloId(int id)
    {
        return BuscarPeloId(id).Adapt<UsuarioResposta>();
    }




    private Usuario BuscarPeloId(int id, bool tracking = true)
    {
        var usuario = _usuarioRepositorio.BuscarUsuarioPeloId(id, tracking);

        if (usuario is null)
        {
            throw new Exception("Usuário não encontrado");
        }

        return usuario;
    }

    public void RemoverUsuario(int id)
    {
        var usuario = BuscarPeloId(id);

        _usuarioRepositorio.RemoverUsuario(usuario);
    }

    public UsuarioResposta AtualizarUsuario(int id, UsuarioCriarAtualizar usuarioEditado)
    {

        var usuario = BuscarPeloId(id);

        //verificar se está alterando o email
        if (usuario.Email != usuarioEditado.Email)
        {
            var usuarioExistente = _usuarioRepositorio.BuscarUsuarioPeloEmail(usuarioEditado.Email);
            if (usuarioExistente is not null)
            {
                throw new EmailException();
            }
        }

        //-------------------------------

        int idPerfil = usuarioEditado.Perfil;


        var perfilbusca = _perfilRepositorio.buscarPerfilPeloId(idPerfil);

        if (perfilbusca is null)
        {
            throw new BadHttpRequestException("Perfil não Existente");
        }




        //Copiar os dados da requisicao pro modelo
        usuarioEditado.Adapt(usuario);


        //---passar perfil novo para o usuario 
        usuario.Perfil = perfilbusca;

        //Salvar no repositorio
        _usuarioRepositorio.AtualizarUsuario();

        //Copiar do modelo para a resposta
        var usuarioResposta = usuario.Adapt<UsuarioResposta>();

        return usuarioResposta;

    }

   



}
