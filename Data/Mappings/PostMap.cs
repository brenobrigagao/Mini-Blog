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

        builder.HasOne(post => post.Autor)
        .WithMany(usuario => usuario.Posts)
        .HasForeignKey(post => post.AutorId)
        .HasConstraintName("FK_Post_Autor")
        .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.categoria)
            .WithMany(x => x.Posts)
            .HasForeignKey(x => x.CategoriaId)
            .HasConstraintName("FK_Post_Category")
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(x => x.Tags)
            .WithMany(x => x.Posts)
            .UsingEntity<Dictionary<string, object>>(
            "PostTag",
            tag => tag.HasOne<Tag>()
                  .WithMany()
                  .HasForeignKey("TagId")
                  .HasConstraintName("FK_PostTag_TagId"),
            post => post.HasOne<Post>()
                   .WithMany()
                   .HasForeignKey("PostId")
                   .HasConstraintName("FK_PostTag_PostId")
        );
    }
}