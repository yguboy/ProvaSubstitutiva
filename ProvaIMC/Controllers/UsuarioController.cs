namespace ProvaIMC.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProvaIMC.Data;
using ProvaIMC.Models;

[ApiController]
[Route("usuario")]
public class UsuarioController : ControllerBase
{
    private readonly AppDataContext _context;
    public UsuarioController(AppDataContext context)
    {
        _context = context;
    }
[HttpGet]
[Route("listar")]
public IActionResult Listar()
{
    try
    {
        List<Usuario> usuarios = _context.Usuarios.ToList();
        return Ok(usuarios);
    }
    catch (Exception e)
    {
        return BadRequest(e.Message);
    }
}

[HttpPost]
[Route("cadastrar")]
public IActionResult Cadastrar ([FromBody] Usuario usuario) 
{
    try 
        {
            Usuario usuarioNovo = new(){
                Nome = usuario.Nome,
                Nascimento = usuario.Nascimento
            };

            _context.Add(usuarioNovo);
            _context.SaveChanges();
            return Created("", usuarioNovo);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}