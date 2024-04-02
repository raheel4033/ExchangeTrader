using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class Product
    {
        [Key]
        public int productID { get; set; }

        [MaxLength(10)]
        public string? Symbol { get; set; }

        [Required]
        public int lotSize { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal tickSize { get; set; }

        [Column(TypeName = "nvarchar(3)")]
        public string? qouteCurrency { get; set; }

        [Column(TypeName = "nvarchar(3)")]
        public string? settleCurrency { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? field { get; set; }

    }
}
