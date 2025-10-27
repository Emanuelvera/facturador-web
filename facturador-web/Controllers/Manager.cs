using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facturador_web.Models;
using facturador_web.Views;
using System.Numerics;
using facturador_web.Data;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace facturador_web.Controllers
{
    internal class Manager
    {
        Writer writer = new Writer();
        Reader reader = new Reader(); // Ensure this instance is used for non-static methods  

        private readonly AppDbContext _context;

        public Manager(AppDbContext context)
        {
            _context = context;
        }

        public void RunApp()
        {
            int option;
            bool main = true;
            bool main2 = true;

            this.AltaFactura();
            Console.ReadKey();

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
                                default:
                                    Console.WriteLine("Error...");
                                    Console.ReadKey();
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
                                default:
                                    Console.WriteLine("Error...");
                                    Console.ReadKey();
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

        public void AddBill()
        {
            bool flag = false;

            Console.WriteLine("Ingrese razon social");
            string name = Reader.StringReader();
            Console.WriteLine("Buscando cliente");
            Console.WriteLine(" ... ");
            Console.WriteLine(" ... ");
            Console.WriteLine("Cliente encontrado cliente");

            do
            {
                Console.Clear();
                Console.WriteLine("Ingrese el tipo de factura (A, B, C): ");
                char value = Reader.CharReader();
                if (value == 'A' || value == 'B' || value == 'C')
                {
                    flag = true;
                    Console.WriteLine("Factura agregada exitosamente.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Tipo de factura inválido. Debe ser A, B o C.");
                    Console.ReadKey();
                }
            } while (!flag);

            Console.WriteLine("Mostrando Datos de factura");
            Console.WriteLine("********************************");
            Console.WriteLine("Fecha: 26/10/2025");
            Console.WriteLine("Tipo de factura: A");
            Console.WriteLine("Razón social: Fiat");
            Console.WriteLine("Cuil / Cuit: 2038178877");
            Console.WriteLine("Domicilio: Manuel leiva 5493");
            Console.WriteLine("********************************");

        }
        private void AltaFactura()
        {
            Console.Clear();
            Console.WriteLine("===Alta de Factura ===");
            Console.Write("Ingrese Razon social: ");
            string razonSocial = Console.ReadLine();

            // Use a lambda expression to filter the Clientes DbSet
            var cliente = _context.Clientes
            .FirstOrDefault(c => c.CompanyName.Trim().ToLower() == razonSocial.Trim().ToLower());


            if (cliente == null)
            {
                Console.WriteLine("⚠️ Cliente no encontrado.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Cliente encontrado: {cliente.CompanyName}");
            Console.ReadKey();
        }

        }
}