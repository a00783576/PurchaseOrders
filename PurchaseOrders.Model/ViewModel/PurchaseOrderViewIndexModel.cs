using PurchaseOrders.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders.Model.ViewModel
{
    public class PurchaseOrderViewIndexModel
    {
        public List<PurchaseOrderViewModel> PurchaseOrders { get; set; }
        public SelectCategoryViewModel Categories { get; set; }
    }
}
