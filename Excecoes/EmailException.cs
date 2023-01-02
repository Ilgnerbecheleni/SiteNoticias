namespace SiteNoticias.Excecoes;

public class EmailException : Exception
{
    public EmailException() : base("Já existe um usuário com esse email")
    {

    }
}