using Microsoft.EntityFrameworkCore;
using MercadoRaiz.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MercadoRaiz.Configuration
{

    public class ProdutoConfiguration : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
                        // builder.ToTable("Produtos");
                        // builder.HasKey(p => p.Id);
                        // builder.Property(p => p.CodigoBarras).HasColumnType("VARCHAR(25)").IsRequired();
                        // builder.Property(p => p.Nome).HasColumnType("VARCHAR(25)").IsRequired();
                        // builder.Property(p => p.Valor).IsRequired();
                        // builder.Property(p => p.MedidaProduto).HasConversion<string>(); //O Tipo produto é informada como uma String
                        // builder.Property(p => p.Descricao).HasColumnType("VARCHAR(150)").IsRequired(false);
        }
    }
}