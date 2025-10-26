using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturador_web.Views
{
    public class Writer
    {
        // Menu Principal
        public static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine(new string('-', 100));
            Console.WriteLine("Bienvenido al Facurador Web de ARCA");
            Console.WriteLine(new string('-', 100));

            Console.Write("\n1- Gestion de Facturas\n2- Gestion de Clientes\n3- Salir del Programa" +
                "\n\nIngrese la opcion que desee: ");
        }

        // Menu Gestion de Clientes
        public static void ShowCustomerMenu()
        {
            Console.Clear();
            Console.WriteLine("Gestion de Clientes");

            Console.Write("\n1- Agregar Cliente al Sistema\n2- Modificar Cliente del Sistema" +
                "\n3- Eliminar Cliente del Sistema\n4- Consultar en Sistema\n5- Volver al Menu Anterior" +
                "\n\nIngrese la opcion que desee: ");

        }

        // Menu Gestion de Facturas
        public static void ShowInvoiceMenu()
        {
            Console.Clear();
            Console.WriteLine("Gestion de Facturas");

            Console.Write("\n1- Emitir Factura\n2- Ver/Consultar Factura\n3- Volver al Menu Anterior" +
                "\n\nIngrese la opcion que desee: ");

        }

        public static void CloseProgram()
        {
            Console.Clear();
            Console.WriteLine(new string('-', 100));
            Console.WriteLine("Gracias por usar Facturador ARCA... Saludos!!!");
            Console.WriteLine(new string('-', 100));
        }
    }
}
