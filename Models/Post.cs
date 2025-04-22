namespace Blog.Models;

public class Post
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public string? Slug { get; set; }
    public string? Body { get; set; }

    public int AutorId { get; set; }           
    public Usuario? Autor { get; set; }  
    public int CategoriaId {get;set;}
    public Categoria? categoria {get;set;} 
    public List<Tag> Tags {get;set;} = new();        
    public DateTime CriadoEm { get; set; } = DateTime.Now;
}
