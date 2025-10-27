using facturador_web.Controllers;
using facturador_web.Data;
using facturador_web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        //Crear el contenedor de servicios
        var serviceCollection = new ServiceCollection();

        //Registrar el DbContext con SQLite
        serviceCollection.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Data Source=facturador.db"));

        // Registrar Manager en el contenedor
        serviceCollection.AddTransient<Manager>();

        //Construir el contenedor (ServiceProvider)
        var serviceProvider = serviceCollection.BuildServiceProvider();

        //Obtener el Manager ya configurado con el contexto
        var manager = serviceProvider.GetRequiredService<Manager>();

        //Obtener una instancia del DbContext
        var db = serviceProvider.GetRequiredService<AppDbContext>();

        //Asegurar migraciones aplicadas
        db.Database.Migrate();

        if (!db.Clientes.Any())
        {
            db.Clientes.Add(new Cliente
            {
                CompanyName = "Stellantis",
                CuilCuit = 2038178877,
                Address = "Calle falsa 123"
            });
            db.SaveChanges();
        }

        manager.RunApp();

    }
}