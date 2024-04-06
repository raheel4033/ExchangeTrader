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
        
        public int OrderId { get; set; }
        public int productID { get; set; }
        public Product Product { get; set; }
        public long price { get; set; }
        public long  quantity { get; set; }
        public string? side { get; set; }
        public string? orderStatus { get; set; }
        public string? orderType { get; set; }
        public string? timeInForce { get; set; }
        public string? symbol { get; set; }
        public long? userId { get; set; }
        public string? clientOrderId { get; set; }
        public string? broker { get; set;}
        public long accountID { get; set; }
        public long entryTime { get; set; }
        public long transactionTime { get; set; }



    }

}
