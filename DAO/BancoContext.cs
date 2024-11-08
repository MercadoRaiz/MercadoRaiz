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

        public DbSet<UsuarioModel> Produtos { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BancoContext).Assembly);

        }
    }
}