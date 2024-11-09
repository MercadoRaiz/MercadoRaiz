using Microsoft.EntityFrameworkCore;
using MercadoRaiz.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MercadoRaiz.Configuration
{

    public class PedidoConfiguration : IEntityTypeConfiguration<PedidoModel>
    {
        public void Configure(EntityTypeBuilder<PedidoModel> builder)
        {
                        builder.ToTable("Pedido");
                        builder.HasKey(p => p.Id_Pedido);
                        builder.Property(p => p.Data).IsRequired();
                        builder.Property(p => p.Valor_Total).IsRequired();
                        builder.Property(p => p.CPF_Cliente).IsRequired();
                        
        }
    }
}
