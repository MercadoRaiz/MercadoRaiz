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
                        builder.Property(p => p.Nome).HasConversion<string>(); //ENUM
                        builder.Property(p => p.Valor).IsRequired();
                        builder.Property(p => p.Estoque).IsRequired();
                        builder.Property(p => p.CPF_Produtor).IsRequired();
                        builder.Property(p => p.Cidade).HasColumnType("VARCHAR(25)").IsRequired();
                        builder.Property(p => p.UF).HasConversion<string>(); //ENUM

                        
                    
                        
        }
    }
}
