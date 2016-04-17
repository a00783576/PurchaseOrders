using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders.Model.Domain
{
    public class PurchaseOrder
    {
        public int IdOrder { get; set; }
        public DateTime OrderDate { get; set; }
        public bool OrderStatus { get; set; }
        public string SupplierName { get; set; }
    }
}
