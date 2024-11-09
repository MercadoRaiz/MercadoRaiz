using MercadoRaiz.Models;

namespace MercadoRaiz.Repositorio
{

    public interface IUsuarioRepositorio
    {

        UsuarioModel CadastrarUsuario(UsuarioModel usuario);
        bool LoginUsuario (string CPFDigitado, string senhaDigitada);


    }
}