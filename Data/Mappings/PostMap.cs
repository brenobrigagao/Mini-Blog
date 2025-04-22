using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Blog.Models;

namespace Blog.Data.Mappings;

public class PostMap : IEntityTypeConfiguration<Post>{
    public void Configure(EntityTypeBuilder<Post> builder){
        builder.ToTable("Post");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Titulo).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Slug).IsRequired().HasMaxLength(80);
        builder.Property(x => x.Body).IsRequired();
        builder.Property(x => x.CriadoEm).HasDefaultValueSql("GETDATE()");

        builder.HasOne(X => X.Autor).WithMany(X => X.Posts)
        .HasForeignKey(x => x.AutorId)
        .HasConstraintName("FK_Post_Autor")
        .OnDelete(DeleteBehavior.Cascade);
    }
}