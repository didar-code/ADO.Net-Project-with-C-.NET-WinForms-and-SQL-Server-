using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1292886_PropertySales.ViewModels
{
    public class SalesInfoViewModel
    {
        public int SalesId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string ClientName { get; set; }
        public string MobileNo { get; set; }
        public bool IsPaid { get; set; }
        public string ClientImage { get; set; }
        public byte[] ImageBinary { get; set; }

       
        public int PaymentId { get; set; }
        public string PaymentType { get; set; }

        
        //public int PropertyId { get; set; }
        //public string PropertyType { get; set; }
        //public string Location { get; set; }
    }
}
