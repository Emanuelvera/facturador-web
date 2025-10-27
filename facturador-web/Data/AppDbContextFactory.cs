using facturador_web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace facturador_web.Data
{
    //Esta clase solo se usa en tiempo de diseño (Add-Migration, Update-Database)
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite("Data Source=facturador.db");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}