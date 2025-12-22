using Microsoft.EntityFrameworkCore;
using ProjetoWebApi.Models;

namespace ProjetoWebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options){}
    
        public DbSet<Personagem> DBZ {get; set;}
    }
}