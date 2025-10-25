using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturador_web.Models
{
    public class Writer
    {
        // Menu Principal
        public static int ShowMainMenu()
        {
            Console.WriteLine(new string('-', 100));
            Console.WriteLine("Bienvenido al Facurador Web de ARCA");
            Console.WriteLine(new string('-', 100));

            Console.WriteLine("\n1- Gestion de Facturas\n2- Gestion de Clientes\n3- Salir del Programa");

            return Reader.IntReader("Ingrese la opcion que desee: ");
        }

        // Menu Gestion de Clientes
        public static int ShowCustomerMenu()
        {
            Console.WriteLine("Gestion de Clientes");

            Console.WriteLine("\n1- Agregar Cliente al Sistema\n2- Modificar Cliente del Sistema" +
                "\n3- Eliminar Cliente del Sistema\n4- Consultar en Sistema\n5- Volver al Menu Anterior");

            return Reader.IntReader("Ingrese la opcion que desee: ");
        }

        // Menu Gestion de Facturas
        public static int ShowInvoiceMenu()
        {
            Console.WriteLine("Gestion de Facturas");

            Console.WriteLine("\n1- Emitir Factura\n2- Ver/Consultar Factura\n3- Volver al Menu Anterior");

            return Reader.IntReader("Ingrese la opcion que desee: ");
        }
    }
}
