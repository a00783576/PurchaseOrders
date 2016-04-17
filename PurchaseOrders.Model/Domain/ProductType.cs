using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders.Model.Domain
{
    public class ProductType
    {
        public int IdProductType { get; set; }
        public string Description { get; set; }
        public int IdCategory { get; set; }
    }
}
