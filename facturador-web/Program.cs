using facturador_web.Controllers;
using facturador_web.Data;
using facturador_web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        Manager manager = new Manager();

        manager.RunApp();

        //Crear el contenedor de servicios
        var serviceCollection = new ServiceCollection();

        //Registrar el DbContext con SQLite
        serviceCollection.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Data Source=facturador.db"));

        //Construir el contenedor (ServiceProvider)
        var serviceProvider = serviceCollection.BuildServiceProvider();

        //Obtener una instancia del DbContext
        var db = serviceProvider.GetRequiredService<AppDbContext>();

        //Asegurar migraciones aplicadas
        db.Database.Migrate();

        Console.WriteLine("✅ Base de datos inicializada correctamente.");

        
    }
}