using MercadoRaiz.Configuration;
using MercadoRaiz.Models;

namespace MercadoRaiz.Repositorio
{

    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;


        public UsuarioRepositorio(BancoContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }

        public UsuarioModel CadastrarUsuario(UsuarioModel usuario)
        {

            _bancoContext.Set<UsuarioModel>().Add(usuario); //salvar no banco de dados 
            _bancoContext.SaveChanges();


            return usuario;
        }

        public bool LoginUsuario(string cpf, string senha)
        {
            var usuario = _bancoContext.Usuario
                        .Where(u => u.CPF == cpf)
                        .Select(u => new { u.CPF, u.Senha }) 
                        .FirstOrDefault();
            if (usuario != null) 
            {
             return usuario.CPF == cpf && usuario.Senha == senha;
            } // Retornar falso se o usuário não for encontrado return false;

            return false;
        }

        public string TipoUsuario(string cpf)
        {
            var usuario = _bancoContext.Usuario
                        .Where(u => u.CPF == cpf)
                        .Select(u => new { u.TipoUsuario})
                        .FirstOrDefault();


            return usuario.TipoUsuario.ToString();
        }
    }

}




