using Microsoft.EntityFrameworkCore;
using ProvaIMC.Models;
namespace ProvaIMC.Data;
public class AppDataContext : DbContext
{
public AppDataContext(DbContextOptions<AppDataContext> options) :
base(options){

}
public DbSet<Usuario> Humanos {get; set;}
}