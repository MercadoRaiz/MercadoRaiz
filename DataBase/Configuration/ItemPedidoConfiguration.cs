using Microsoft.EntityFrameworkCore;
using MercadoRaiz.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MercadoRaiz.Configuration
{

    public class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedidoModel>
    {
        public void Configure(EntityTypeBuilder<ItemPedidoModel> builder)
        {
                        builder.ToTable("ItemPedido");
                        builder.HasKey(p => p.Id_Pedido);
                        builder.Property(p => p.Id_Item).IsRequired();
                        builder.Property(p => p.Quantidade_Item).IsRequired();
            
        }
    }
}
