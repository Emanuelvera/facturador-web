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
            while (main)
            {
                Writer.ShowMainMenu();
                option = Reader.IntReader();
                

                switch (option)
                {
                    case 1:
                        Console.WriteLine("1");
                        Console.ReadKey();
                        break;
                        
                    case 2:
                        Console.WriteLine("2");
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.WriteLine("3");
                        main = false;
                        Writer.CloseProgram();
                        break;

                    default:
                        Console.WriteLine("Error");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
