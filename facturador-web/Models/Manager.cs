using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facturador_web.Models;


namespace facturador_web.Models
{
    internal class Manager
    {
        Writer writer = new Writer();
        Reader reader = new Reader();   


        public void RunApp()
        {
            int option;
            bool main = true;
            bool main2 = true;

            // Inicio Menu Principal
            while (main)
            {
                Writer.ShowMainMenu();
                option = Reader.IntReader();
                main2 = true;

                switch (option)
                {
                    // Inicio Menu Gestion de Facturas
                    case 1:
                        
                        while (main2)
                        {
                            Writer.ShowInvoiceMenu();
                            option = Reader.IntReader();

                            switch (option)
                            {
                                case 1:
                                    Console.WriteLine("Agregaste Factura");
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.WriteLine("Consultaste Cliente");
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    main2 = false;
                                    break;
                            }
                        }

                        break;
                        
                    //Inicio Menu Gestion de CLientes
                    case 2:

                        while (main2)
                        {
                            Writer.ShowCustomerMenu();
                            option = Reader.IntReader();

                            switch (option)
                            {
                                case 1:
                                    Console.WriteLine("Agregaste Cliente");
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.WriteLine("Modificaste Cliente");
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    Console.WriteLine("Eliminaste Cliente");
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    Console.WriteLine("Consultaste Cliente");
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    main2 = false;
                                    break;
                            }
                        }

                        break;

                    //Opcion Salir Programa
                    case 3:
                        Console.WriteLine("3");
                        main = false;
                        Writer.CloseProgram();
                        break;

                    // Opcion Erronea
                    default:
                        Console.WriteLine("Error");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
