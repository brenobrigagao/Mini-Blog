using Microsoft.EntityFrameworkCore;
using Blog.Models;
using Blog.Data.Mappings;

namespace Blog.Data;

public class BlogDataContext : DbContext{
    public DbSet<Usuario> Usuarios {get;set;}
    public DbSet<Post> Posts {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
   protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.ApplyConfiguration(new UsuarioMap());
    modelBuilder.ApplyConfiguration(new PostMap());
    modelBuilder.ApplyConfiguration(new CategoriaMap());
    modelBuilder.ApplyConfiguration(new TagMap());

}

}