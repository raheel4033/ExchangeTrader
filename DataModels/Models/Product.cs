using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class Product
    {
        public int productID { get; set; }
        public string? Symbol { get; set; }
        public int lotSize { get; set; }
        public decimal tickSize { get; set; }
        public string? qouteCurrency { get; set; }
        public string? settleCurrency { get; set; }
        public string? Description { get; set; }
        public string? field { get; set; }

    }
}
