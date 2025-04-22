using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Blog.Models;

namespace Blog.Data.Mappings;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>{
    public void Configure(EntityTypeBuilder<Usuario> builder){
        builder.ToTable("Usuario");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(200);
        builder.Property(x => x.SenhaHash).IsRequired().HasMaxLength(255);
    }
}