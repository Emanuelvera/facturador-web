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
            Writer.ShowMainMenu();
        }

        

    }
}
