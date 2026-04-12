using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1292886_PropertySales.Entities
{
    public class Property
    {
        public int PropertyId { get; set; }
        public string PropertyType { get; set; }
        public string Location { get; set; }
        public int SalesId { get; set; }
    }
}
