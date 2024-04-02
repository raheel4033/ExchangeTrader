using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int productID { get; set; }
        [ForeignKey("productID")]
        public Product Product { get; set; }

        [Required]
        
        public long price { get; set; }

        [Required]
        
        public long  quantity { get; set; }

        [Column(TypeName = "nvarchar(4)")]

        public string? side { get; set; }

        [Column(TypeName = "nvarchar(4)")]

        public string? orderStatus { get; set; }

        [Column(TypeName = "nvarchar(10)")]

        public string? orderType { get; set; }

        [Column(TypeName = "nvarchar(3)")]

        public string? timeInForce { get; set; }

        [Column(TypeName = "nvarchar(10)")]

        public string? symbol { get; set; }

        
        public long? userId { get; set; }

       

        public string? clientOrderId { get; set; }

        [Column(TypeName = "nvarchar(30)")]

        public string? broker { get; set;}

        [Required]
        public long accountID { get; set; }

        [Required]
       
        public long entryTime { get; set; }

        [Required]
       
        public long transactionTime { get; set; }



    }

}
