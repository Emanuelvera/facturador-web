using facturador_web.Data;
using facturador_web.Models;
using facturador_web.Views;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace facturador_web.Controllers
{
    internal class Manager
    {
        Writer writer = new Writer();
        Reader reader = new Reader();

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
                option = (int)Reader.IntReader();
                main2 = true;

                switch (option)
                {
                    // Inicio Menu Gestion de Facturas
                    case 1:

                        while (main2)
                        {
                            Writer.ShowInvoiceMenu();
                            option = (int)Reader.IntReader();

                            switch (option)
                            {
                                case 1:
                                    this.AddBill();
                                    break;
                                case 2:
                                    this.GetBills();
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
                            option = (int)Reader.IntReader();

                            switch (option)
                            {
                                case 1:
                                    CreateCustomer();
                                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    UpdateCustomer();
                                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    DeleteCustomer();
                                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    ShowCustomer();
                                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    main2 = false;
                                    break;
                                default:
                                    Console.WriteLine("\nDebe ingresar alguna de las opciones validas.");
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

        public void CreateCustomer()
        {
            bool validadorCuitCuil = false;
            long cuitCuil = 0;

            Console.Clear();
            while (!validadorCuitCuil)
            {
                Console.WriteLine("Ingrese Cuit/Cuil (sin guiones ni espacios): ");
                cuitCuil = Reader.IntReader();
                validadorCuitCuil = Cliente.ValidarCuilCuit(cuitCuil);

                var existingClient = _context.Clientes.FirstOrDefault(c => c.CuilCuit == cuitCuil);
                if (existingClient != null)
                {
                    Console.WriteLine("El Cuit/Cuil ya existe en el sistema. Ingrese uno diferente.");
                    validadorCuitCuil = false;
                }
            }

            Console.Clear();

            // Ingreso Razon Social
            Console.WriteLine("Ingrese Nombre de la Razon Social: ");
            string companyName = Reader.StringReader();

            Console.Clear();

            // Ingreso Domicilio
            Console.WriteLine("Ingrese domicilio: ");
            string address = Reader.StringReader();

            // Confirmacion
            Console.Clear();
            Console.WriteLine($"Los datos ingresados: \n*Cuit/Cuil: {Cliente.ArmarCuilCuit(cuitCuil)}\n*Razon social: {companyName}\n*Domicilio: {address}\n");

            bool confirmacion = false;
            while (!confirmacion)
            {
                Console.WriteLine("\n¿Desea confirmar la carga del cliente? s/n");
                string choice = Reader.StringReader().ToLower();

                switch (choice)
                {
                    case "s":
                        this._context.Clientes.Add(new Cliente
                        {
                            CuilCuit = cuitCuil,
                            CompanyName = companyName,
                            Address = address
                        });
                        _context.SaveChanges();

                        Console.WriteLine("Se realizo la carga del cliente.");
                        confirmacion = true;
                        break;


                    case "n":
                        Console.WriteLine("No se realizo la carga del cliente");
                        confirmacion = true;
                        break;


                    default:
                        Console.WriteLine("Ingrese opcion valida s/n: ");
                        break;
                }
            }

        }

        public void UpdateCustomer()
        {
            bool validadorCuitCuil = false;
            long cuitCuil = 0;

            Console.Clear();

            while (!validadorCuitCuil)
            {
                Console.WriteLine("Ingrese el Cuit/Cuil que desea modificar: ");
                cuitCuil = Reader.IntReader();
                validadorCuitCuil = Cliente.ValidarCuilCuit(cuitCuil);
            }

            var cliente = _context.Clientes.FirstOrDefault(c => c.CuilCuit == cuitCuil);

            if (cliente != null)
            {
                Console.WriteLine("Buscando cliente... \n");
                Console.WriteLine("\nCliente encontrado\n");
                Console.WriteLine("Ingrese el nuevo nombre de la razon social: ");
                string newCompanyName = Reader.StringReader();

                Console.WriteLine("Ingrese el nuevo domicilio: ");
                string newAddress = Reader.StringReader();

                cliente.CompanyName = newCompanyName;
                cliente.Address = newAddress;
                _context.SaveChanges();

                Console.WriteLine("\nCliente modificado exitosamente.");
            }
            else
            {
                Console.WriteLine("Cuit/Cuil Inexistente");
            }


        }

        public void DeleteCustomer()
        {
            bool validadorCuitCuil = false;
            long cuitCuil = 0;

            Console.Clear();

            while (!validadorCuitCuil)
            {
                Console.WriteLine("Ingrese el Cuit/Cuil que desea eliminar: ");
                cuitCuil = Reader.IntReader();
                validadorCuitCuil = Cliente.ValidarCuilCuit(cuitCuil);
            }

            var cliente = _context.Clientes.FirstOrDefault(c => c.CuilCuit == cuitCuil);

            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
                Console.WriteLine("Cliente eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Cuit/Cuil Inexistente");
            }
        }

        public void ShowCustomer()
        {
            bool validadorCuitCuil = false;

            long cuitCuil = 0;
            Console.Clear();

            while (!validadorCuitCuil)
            {
                Console.WriteLine("Ingrese el Cuit/Cuil que desea encontrar: ");
                cuitCuil = Reader.IntReader();
                validadorCuitCuil = Cliente.ValidarCuilCuit(cuitCuil);
            }

            var cliente = _context.Clientes.FirstOrDefault(c => c.CuilCuit == cuitCuil);

            Console.Clear();

            if (cliente != null)
            {
                Console.WriteLine("Buscando cliente...\n");
                Console.WriteLine("Cliente encontrado\n");
                Console.WriteLine($"Cuit/Cuil: {Cliente.ArmarCuilCuit(cliente.CuilCuit)}");
                Console.WriteLine($"Razon Social: {cliente.CompanyName}");
                Console.WriteLine($"Domicilio: {cliente.Address}");
            }
            else
            {
                Console.WriteLine("Cuit/Cuil Inexistente");
            }
        }

        //*************************************************************************************************************************************************//
        //                                                                                                                                                 //
        //                                                              MODULO FACTURAS                                                                    //
        //                                                                                                                                                 //
        //*************************************************************************************************************************************************//



        ////////////////////////////////////////////////////////////////
        //                       EMITIR FACTURA                       //
        ////////////////////////////////////////////////////////////////

        public void AddBill()
        {
            char typeValue;
            bool flag = false;
            bool flag2 = false;
            bool flag3 = false;


            //==============================================================
            //              BUSQUEDA CLIENTE POR RAZON SOCIAL
            //==============================================================

            Console.Clear();
            var cliente = GetByCompanyName();

            //==============================================================
            //                     TIPO DE FACTURA
            //==============================================================
            do
            {
                Console.Clear();
                Console.Write("Ingrese el tipo de factura (A, B, C): ");
                typeValue = reader.CharReader();
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
            //                         PREVIEW
            //==============================================================
            int nextNumber = 1;
            var lastFactura = _context.Facturas.OrderByDescending(f => f.Number).FirstOrDefault();
            if (lastFactura != null)
                nextNumber = lastFactura.Number + 1;
            do
            {
                Console.Clear();
                Console.WriteLine($"Factura a emitir (A, B o C): {typeValue}");
                Console.WriteLine($"Cliente: {cliente.CompanyName}\n");
                Console.WriteLine($"-----------------------------------------");
                Console.WriteLine($"Factura:            {typeValue}");
                Console.WriteLine($"Numero:             {nextNumber}");
                Console.WriteLine($"Fecha:              {DateTime.Now.ToShortDateString()}\n");
                Console.WriteLine($"Razon Social:       {cliente.CompanyName}");
                Console.WriteLine($"Cuil/Cuit:          {Cliente.ArmarCuilCuit(cliente.CuilCuit)}");
                Console.WriteLine($"Domicilio:          {cliente.Address}");
                Console.WriteLine($"-----------------------------------------\n");
                Console.Write("¿Los datos son correctos? (S/N): ");
                char respuesta = reader.CharReader();
                respuesta = char.ToUpper(respuesta);
                if (respuesta != 'S')
                {
                    if (respuesta == 'N')
                    {
                        Console.WriteLine("Inicie nuevamente el proceso.\n\nPresione una tecla para volver al menú principal.");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("\nOpcion invalida por favor ingrese S o N.\n\nPresione una tecla para volver a ingresar.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    flag2 = true;
                }
            } while (!flag2);

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
            //              CREACIÓN DE FACTURA
            //==============================================================
            var factura = new Factura
            {
                Type = typeValue,
                Date = DateTime.Now,
                ClienteId = cliente.Id,           //  Vincula el cliente encontrado
                Items = items,
                TotalAmount = items.Sum(i => i.Amount) //  Calcula el total automáticamente
            };

            //==============================================================
            //          PREVIEW DE FACTURA COMPLETA Y VALIDACION
            //==============================================================
            do
            {
                Console.Clear();
                Console.WriteLine($"\n-----------------------------------------");
                Console.WriteLine($"Factura:            {typeValue}");
                Console.WriteLine($"Numero:             {nextNumber}");
                Console.WriteLine($"Fecha:              {DateTime.Now.ToShortDateString()}\n");
                Console.WriteLine($"Razon Social:       {cliente.CompanyName}");
                Console.WriteLine($"Cuil/Cuit:          {Cliente.ArmarCuilCuit(cliente.CuilCuit)}");
                Console.WriteLine($"Domicilio:          {cliente.Address}");
                Console.WriteLine($"-----------------------------------------");

                foreach (var item in items)
                {
                    Console.WriteLine($"Item:           {item.Description}");
                    Console.WriteLine($"Cantidad:       {item.Quantity}");
                    Console.WriteLine($"Precio: $       {item.Amount}");
                    Console.WriteLine($"-----------------------------------------");
                }
                Console.WriteLine($"Importe Total: $     {items.Sum(i => i.Amount)}");

                Console.Write("\n¿Desea emitir esta factura?? (S/N): ");
                char emitir = reader.CharReader();
                emitir = char.ToUpper(emitir);
                if (emitir != 'S')
                {
                    if (emitir == 'N')
                    {
                        Console.WriteLine("Factura no emitida.\n\nPresione una tecla para volver al menú principal.");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("\nOpcion invalida por favor ingrese S o N.\n\nPresione una tecla para volver a ingresar.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    flag3 = true;
                }
            } while (!flag3);

            //==============================================================
            //              GUARDADO DE FACTURA EN DB
            //==============================================================

            _context.Facturas.Add(factura);
            _context.SaveChanges();

            Console.WriteLine($"\nFactura creada con éxito para {cliente.CompanyName}");
            Console.WriteLine($"\nPresione una tecla para salir");
            Console.ReadKey();
        }

        ////////////////////////////////////////////////////////////////
        //                      VER FACTURAS                          //
        ////////////////////////////////////////////////////////////////

        public void GetBills()
        {
            bool flag = false;
            string name;

            //==============================================================
            //              BUSQUEDA DE CLIENTE
            //==============================================================

            var cliente = GetByCompanyName();

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
                    Console.WriteLine($"\n Factura #{factura.Number}");
                    Console.WriteLine($"   Tipo: {factura.Type}");
                    Console.WriteLine($"   Fecha: {factura.Date.ToShortDateString()}");

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
                    Console.WriteLine($"   Total: ${factura.TotalAmount}");
                }
            }
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }



        ////////////////////////////////////////////////////////////////
        //                   METODO CARGAR ITEMS                      //
        ////////////////////////////////////////////////////////////////
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
                int quantity =(int)Reader.IntReader();

                Console.Write("Ingrese el precio total: ");
                float totalPrice = Reader.FloatReader();

                var item = new Item
                {
                    Description = itemName,
                    Quantity = quantity,
                    Amount = totalPrice
                };
                //Desea agregar el item a la lista
                items.Add(item);
                //Guardar items en la base de datos

                Console.WriteLine($"\nItem agregado: {itemName}, Cantidad: {quantity}, Precio total: {totalPrice}");
                Console.ReadKey();
                Console.WriteLine("\n¿Desea agregar otro item? (S/N): ");

                char respuesta = reader.CharReader();
                respuesta = char.ToUpper(respuesta);
                if (respuesta != 'S')
                {
                    if (respuesta == 'N')
                    {
                        masItems = false;
                    }
                    else
                    {
                        Console.WriteLine("\nOpcion invalida por favor ingrese S o N.\n\nPresione una tecla para volver a ingresar.");
                        Console.ReadKey();
                    }
                }
            }
            return items;
        }

        ////////////////////////////////////////////////////////////////
        //              TRAER CLIENTE POR RAZON SOCIAL                //
        ////////////////////////////////////////////////////////////////

        public Cliente GetByCompanyName()
        {
            Cliente cliente = null;
            bool flag = false;
            do
            {
                Console.Clear();
                Console.Write("Ingrese razón social: ");
                string name = Reader.StringReader();

                Console.WriteLine("\nBuscando cliente ...");

                cliente = _context.Clientes.FirstOrDefault(
                    c => c.CompanyName.Trim().ToLower() == name.Trim().ToLower());

                if (cliente == null)
                {
                    Console.WriteLine("\nCliente no encontrado. \nPresione una tecla para intentar nuevamente.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine($"\nCliente encontrado: {cliente.CompanyName}. \n\nPresione una tecla para seguir");
                    Console.ReadKey();
                    flag = true;
                }

            } while (!flag);
            return cliente;

        }
    }

}

