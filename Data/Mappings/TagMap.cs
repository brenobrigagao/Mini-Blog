using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Blog.Models;

namespace Blog.Data.Mappings;

public class TagMap : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tag");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(80);

        builder.Property(x => x.Slug)
            .IsRequired()
            .HasMaxLength(80);

        builder.HasIndex(x => x.Slug, "IX_Tag_Slug")
            .IsUnique();
    }
}
