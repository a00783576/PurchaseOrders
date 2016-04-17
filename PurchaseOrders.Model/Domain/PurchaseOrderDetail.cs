using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders.Model.Domain
{
    public class PurchaseOrderDetail
    {
        public int IdOrderDetail { get; set; }
        public int IdOrder { get; set; }
        public int Sequence { get; set; }
        public int IdProduct { get; set; }
        public decimal Amount { get; set; }
        public decimal Total { get; set; }
        public string Comments { get; set; }
    }
}
