using MercadoRaiz.Models;

namespace MercadoRaiz.Repositorio
{

    public interface IUsuarioRepositorio
    {

        UsuarioModel CadastrarUsuario(UsuarioModel usuario);

        bool LoginUsuario(string cpf, string senha);

        string TipoUsuario(string cpf);
        bool verificarDuplicidadeCPF(string cpf);
        public void AtualizarSenha(string cpf, string novaSenha);
        public UsuarioModel BuscarPorCPF(string cpf);


    }
}