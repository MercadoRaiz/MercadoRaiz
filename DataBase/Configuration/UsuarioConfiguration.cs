using Microsoft.EntityFrameworkCore;
using MercadoRaiz.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MercadoRaiz.Configuration
{

    public class UsuarioConfiguration : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
                        builder.ToTable("Usuario");
                        builder.HasKey(p => p.Id);
                        builder.Property(p => p.CPF).HasColumnType("VARCHAR(11)").IsRequired();
                        builder.Property(p => p.Senha).HasColumnType("VARCHAR(25)").IsRequired();
                        builder.Property(p => p.Nome).HasColumnType("VARCHAR(30)").IsRequired();
                        builder.Property(p => p.Celular).IsRequired();
                        builder.Property(p => p.TipoUsuario).HasConversion<string>(); //O Tipo produto é informada como uma String
                        
        }
    }
}

