namespace ProvaIMC.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProvaIMC.Data;
using ProvaIMC.Models;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly AppDataContext _context;
    public UsuarioController(AppDataContext context)
    {
        _context = context;
    }
[HttpGet]
[Route("api/controller/listar")]
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
[Route("api/controller/cadastrar")]
public IActionResult Cadastrar ([FromBody] Usuario usuario) 
{
    try 
        {
            _context.Add(usuario);
            _context.SaveChanges();
            return Created("", usuario);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}