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






            

     public bool LoginUsuario(string CPFDigitado, string senhaDigitada)
    {
        // 1. Verificar se o usuário existe no banco
        var usuario = _bancoContext.Usuario
                              .FirstOrDefault(u => u.CPF == CPFDigitado);

        if (usuario == null)
        {
            // Se o usuário não existe, retorna false
            return false;
        }

        // 2. Comparar a senha fornecida com a senha armazenada no banco (sem hash)
        if (usuario.Senha != senhaDigitada)
        {
            // Se a senha não for válida, retorna false
            return false;
        }

        // 3. Retorna true se o login for bem-sucedido
        return true;
    }
}
}

            
        

        
