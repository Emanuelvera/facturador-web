using facturador_web.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturador_web.Models
{

    public class Cliente
    {
        Reader reader = new Reader();


        [Key]
        public int Id { get; set; }

        [Required]
        public long CuilCuit { get; set; }

        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        //RELACIONES
        public List<Factura> Facturas { get; set; } = new List<Factura>();



        public static bool ValidarCuilCuit(long CuilCuit)
        {
            string cuilCuitStr = CuilCuit.ToString();
            if (cuilCuitStr.Length != 11)
            {
                Console.WriteLine("Ingrese un numero de cuit o cuil valido, sin caracteres especiales o espacios");
                return false;
            }
            return true;
        }

        public static string ArmarCuilCuit(long CuilCuit)
        {
            string cuilCuitStr = CuilCuit.ToString();
            return cuilCuitStr.Insert(2, "-").Insert(11, "-");
        }

    }
}