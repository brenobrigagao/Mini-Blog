using Microsoft.AspNetCore.Mvc;
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly BlogDataContext _context;

    public UsuarioController(BlogDataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _context.Usuarios.ToListAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _context.Usuarios.FindAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUsuario([FromBody] Usuario user)
    {
        if(user == null){
            return BadRequest();
        }
        _context.Usuarios.Add(user);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarUsuario(int id, [FromBody] Usuario user){
        if(id != user.Id){
            return BadRequest();
        }
        _context.Entry(user).State = EntityState.Modified;
        try{
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException){
            if(!UsuarioExists(id)){
                return NotFound();
            }
            else{
                throw;
            }    
        }
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarUsuario(int id){
        var user = await _context.Usuarios.FindAsync(id);
        if(user == null){
            return NotFound();
        }
        _context.Usuarios.Remove(user);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool UsuarioExists(int id){
        return _context.Usuarios.Any(e => e.Id == id);
    }
}
