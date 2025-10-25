using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturador_web.Models
{
    internal class Cliente
    {
        public int Id { get; set; }
        public int CuilCuit { get; set; }
        public string RazonSocial { get; set; }
        public string Domicilio { get; set; }

        public static bool ValidarCuilCuit(int CuilCuit)
        {
            string cuilCuitStr = CuilCuit.ToString();
            if (cuilCuitStr.Length != 11)
            {
                Console.Write("Ingrese un numero de cuit o cuil valido, sin caracteres especiales o espacios");
            }
            return true;
        }

        public static string ArmarCuilCuit(int CuilCuit)
        {
            string cuilCuitStr = CuilCuit.ToString();
            return cuilCuitStr.Insert(2, "-").Insert(11, "-");
        }
        

    }
}
