using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturador_web.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Amount { get; set; }
        [Required]
        public int FacturaId { get; set; }

        [ForeignKey("FacturaId")]
        public Factura Factura { get; set; }

        public void ValidateDescription()
        {
            if (string.IsNullOrWhiteSpace(Description))
            {
                throw new ArgumentException("Description cannot be empty.");
            }
        }

        public void ValidateQuantity()
        {
            if (Quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.");
            }
        }

        public void ValidateAmount()
        {
            if (Amount < 0)
            {
                throw new ArgumentException("Amount cannot be negative.");
            }
        }

    }
}
