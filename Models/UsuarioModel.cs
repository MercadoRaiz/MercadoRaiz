namespace MercadoRaiz.Models
{


public class UsuarioModel
{
    public int CPF {get; set;}
    public string Nome { get; set; }
    public string Celular {get; set; }
    public string Senha {get; set; }
    public ETipoUsuario TipoUsuario {get; set; }
    
}

    
}