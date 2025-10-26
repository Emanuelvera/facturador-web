using facturador_web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FacturadorArca.Data
{
    // Esta clase se usa solo en tiempo de diseño (Add-Migration, Update-Database)
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // 🔧 Cambiá el nombre del archivo si querés otra ruta
            optionsBuilder.UseSqlite("Data Source=facturador.db");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}