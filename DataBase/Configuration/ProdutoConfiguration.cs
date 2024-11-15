using Microsoft.EntityFrameworkCore;
using MercadoRaiz.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MercadoRaiz.Configuration
{

    public class ProdutoConfiguration : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
                        builder.ToTable("Produto");
                        builder.HasKey(p => p.Id_Produto);
                        builder.Property(p => p.Nome).HasConversion<string>(); //O Tipo produto é informada como uma String
                        builder.Property(p => p.Valor).IsRequired();
                        builder.Property(p => p.Estoque).IsRequired();
                        builder.Property(p => p.CPF_Produtor).IsRequired();

                        
                    
                        
        }
    }
}
