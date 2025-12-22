using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ProjetoWebApi.Data;

namespace ProjetoWebApi
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            
        
            var connectionString = "server=localhost; database=DBZ; User=root; Password=abc12345;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}