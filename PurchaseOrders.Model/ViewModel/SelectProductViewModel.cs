using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PurchaseOrders.Model.ViewModel
{
    public class SelectProductViewModel
    {
        public int IdProduct { get; set; }
        public IEnumerable<SelectListItem> List { get; set; }
    }
}
