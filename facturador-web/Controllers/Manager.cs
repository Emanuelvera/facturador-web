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
using System.Runtime.InteropServices;
using System.Xml.Linq;


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
                                    this.AddBill();
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    this.GetBills();
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

        ////////////////////////////////////////////////////////////////
        //                       EMITIR FACTURA                       //
        ////////////////////////////////////////////////////////////////

        public void AddBill()
        {
            char typeValue;
            bool flag = false;

            //==============================================================
            //              RAZON SOCIAL Y BUSQUEDA CLIENTE
            //==============================================================

            Console.Clear();
            Console.Write("Ingrese razon social: ");
            string name = Reader.StringReader();

            Console.WriteLine("Buscando cliente ...\n");

            var cliente = _context.Clientes.FirstOrDefault(c => c.CompanyName.Trim().ToLower() == name.Trim().ToLower());

            if (cliente == null)
            {
                Console.WriteLine("⚠️ Cliente no encontrado. Presione una tecla para volver al menu principal");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine($"Cliente encontrado: {cliente.CompanyName}, Presione una tecla para continuar");
                Console.ReadKey();
            }

            //==============================================================
            //              TIPO DE FACTURA
            //==============================================================
            do
            {

                Console.Clear();
                Console.Write("Ingrese el tipo de factura (A, B, C): ");
                typeValue = Reader.CharReader();
                typeValue = char.ToUpper(typeValue);
                if (typeValue == 'A' || typeValue == 'B' || typeValue == 'C')
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("\nTipo de factura inválido. Debe ser A, B o C.");
                    Console.ReadKey();
                }
            } while (!flag);


            //==============================================================
            //              PREVIEW
            //==============================================================
            do
            {
                Console.Clear();
                Console.WriteLine($"Factura:           |{typeValue}");
                Console.WriteLine($"Numero:            |");
                Console.WriteLine($"Fecha:             |{DateTime.Now}\n");
                Console.WriteLine($"Razon Social:      |{name}");
                Console.WriteLine($"Factura:           |");
                Console.WriteLine($"Factura:           |");
                Console.WriteLine($"Factura:           |");
                Console.WriteLine($"Factura:           |");

            } while (!flag);

            //==============================================================
            //              ITEMS
            //==============================================================

            // Usar el método para cargar los items
            var items = LoadItems();
            foreach (var item in items)
            {
                Console.WriteLine($"Item: {item.Description}/n, Cantidad: {item.Quantity}, Precio: {item.Amount}");
            }

            //==============================================================
            //              CREACIÓN Y GUARDADO FACTURA
            //==============================================================
            var factura = new Factura
            {
                Type = typeValue,
                Date = DateTime.Now,
                ClienteId = cliente.Id,           //  Vincula el cliente encontrado
                Items = items,
                TotalAmount = items.Sum(i => i.Amount) //  Calcula el total automáticamente
            };

            _context.Facturas.Add(factura);
            _context.SaveChanges();

            Console.WriteLine($"Factura creada con éxito para {cliente.CompanyName}");
            Console.WriteLine($"Número: {factura.Number} | Tipo: {factura.Type} | Total: ${factura.TotalAmount}");
            Console.ReadKey();
        }

        private List<Item> LoadItems()
        {
            var items = new List<Item>();
            bool masItems = true;
            while (masItems)
            {
                Console.Clear();
                Console.WriteLine("Ingrese Item");
                Console.Write("Ingrese el nombre del item: ");
                string itemName = Reader.StringReader();

                Console.Write("Ingrese la cantidad: ");
                int quantity = Reader.IntReader();

                Console.Write("Ingrese el precio total: ");
                float totalPrice = Reader.FloatReader();

                var item = new Item
                {
                    Description = itemName,
                    Quantity = quantity,
                    Amount = totalPrice
                };
                items.Add(item);

                Console.WriteLine($"Item agregado: {itemName}, Cantidad: {quantity}, Precio Unitario: {totalPrice}");
                Console.ReadKey();
                Console.WriteLine("¿Desea agregar otro item? (S/N): ");
                char respuesta = Reader.CharReader();
                respuesta = char.ToUpper(respuesta);
                if (respuesta != 'S')
                {
                    masItems = false;
                }
            }
            return items;
        }

        /*public string GetCompanyName()
        {
            string name;
            bool flag = false;
            do
            {
                Console.WriteLine("Ingrese razon social\n");
                name = Reader.StringReader();

                Console.WriteLine("Buscando cliente ...");

                var cliente = _context.Clientes.FirstOrDefault(c => c.CompanyName.Trim().ToLower() == name.Trim().ToLower());

                if (cliente == null)
                {
                    Console.WriteLine("Cliente no encontrado, presione una tecla para intentar nuevamente.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine($"Cliente encontrado: {cliente.CompanyName}, presione una tecla para seguir");
                    Console.ReadKey();
                    flag = true;
                }

            } while (!flag);
            return name;

        }*/


        ////////////////////////////////////////////////////////////////
        //                      VER FACTURAS                          //
        ////////////////////////////////////////////////////////////////

        public void GetBills()
        {
            bool flag = false;
            string name;
            Cliente cliente = null;

            //==============================================================
            //              BUSQUEDA DE CLIENTE
            //==============================================================
            do
            {
                Console.Clear();
                Console.WriteLine("Ingrese razón social del cliente:");
                name = Reader.StringReader();

                Console.WriteLine("Buscando cliente...");

                cliente = _context.Clientes.FirstOrDefault(c => c.CompanyName.Trim().ToLower() == name.Trim().ToLower());

                if (cliente == null)
                {
                    Console.WriteLine("⚠️ Cliente no encontrado, presione una tecla para intentar nuevamente.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine($"✅ Cliente encontrado: {cliente.CompanyName}");
                    Console.ReadKey();
                    flag = true;
                }

            } while (!flag);

            //==============================================================
            //              OBTENER FACTURAS DEL CLIENTE
            //==============================================================
            var facturas = _context.Facturas
                .Where(f => f.ClienteId == cliente.Id)
                .Include(f => f.Items)  // Incluye los ítems relacionados
                .ToList();

            Console.Clear();
            Console.WriteLine($"=== FACTURAS DE {cliente.CompanyName.ToUpper()} ===");

            if (facturas.Count == 0)
            {
                Console.WriteLine("⚠️ Este cliente no tiene facturas registradas.");
            }
            else
            {
                int cont = 1;
                foreach (var factura in facturas)
                {
                    Console.WriteLine($"\n📄 Factura #{factura.Number}");
                    Console.WriteLine($"   Tipo: {factura.Type}");
                    Console.WriteLine($"   Fecha: {factura.Date.ToShortDateString()}");
                    Console.WriteLine($"   Total: ${factura.TotalAmount}");
                    Console.WriteLine("   Ítems:");

                    if (factura.Items != null && factura.Items.Count > 0)
                    {
                        foreach (var item in factura.Items)
                        {
                            Console.WriteLine($"      - {item.Description}: {item.Quantity} x ${item.Amount}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("      (Sin ítems)");
                    }

                    cont++;
                }
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }



    }
}
