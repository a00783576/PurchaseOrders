using PurchaseOrders.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders.Model.ViewModel
{
    public class PurchaseOrderViewModel
    {
        public int IdOrder { get; set; }
        public DateTime OrderDate { get; set; }
        public string SupplierName { get; set; }
        public string Description { get; set; }
    }
}
