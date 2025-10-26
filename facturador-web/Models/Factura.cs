using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturador_web.Models
{
    public class Factura
    {
        [Required]
        public char Type  { get; set; }

        [Key]
        public int Number { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public float TotalAmount { get; set; }

        [Required]
        public int ClienteId { get; set; }

        // Relacion

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();
        
        public void GenerateInvoiceNumber()
        {
            
        }

        public void CalculateTotalAmount()
        {

        }

        public string GenerateDate()
        {
            DateTime currentDate = DateTime.Today;
            return currentDate.ToString("dd/MM/yyyy");
        }
    }
}
