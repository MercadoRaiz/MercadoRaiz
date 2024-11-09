using Microsoft.EntityFrameworkCore;
using MercadoRaiz.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MercadoRaiz.Configuration
{
    public class PropriedadeConfiguration : IEntityTypeConfiguration<PropriedadeModel>
    {
        public void Configure(EntityTypeBuilder<PropriedadeModel> builder)
        {
                        builder.ToTable("Propriedade");
                        builder.HasKey(p => p.IdPropriedade);
                        builder.Property(p => p.Cidade).HasColumnType("VARCHAR(25)").IsRequired();
                        builder.Property(p => p.SiglaEstado).HasConversion<string>(); //O Tipo produto é informada como uma String
                        builder.Property(p => p.CPFProdutor).IsRequired();
                        
                        
        }
    }


}