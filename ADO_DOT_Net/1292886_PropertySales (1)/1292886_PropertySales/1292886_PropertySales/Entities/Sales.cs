using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1292886_PropertySales.Entities
{
    public class Sales
    {
        public int SalesId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string ClientName { get; set; }
        public string MobileNo { get; set; }
        public string ClientImage { get; set; }
        public int PaymentId { get; set; }
        public bool IsPaid { get; set; }

        // Navigation properties
        public List<Property> Properties { get; set; } = new List<Property>();
    }
}
