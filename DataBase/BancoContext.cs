using MercadoRaiz.Models;
using Microsoft.EntityFrameworkCore;



namespace MercadoRaiz.Configuration
{
    

 public class BancoContext : DbContext     
    {

        // private static readonly ILoggerFactory _logger = LoggerFactory.Create(p=>p.AddConsole()); //log das querys

       public BancoContext(DbContextOptions<BancoContext> options)
        : base(options)
    {
    }

        public DbSet<UsuarioModel> Usuario { get; set; } 
        public DbSet<PropriedadeModel> Propriedade { get; set; } 
        public DbSet<PedidoModel> Pedido { get; set; } 
         public DbSet<ItemPedidoModel> ItemPedido { get; set; } 
        public DbSet<ProdutoModel> Produto { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BancoContext).Assembly);

        }
    }
}