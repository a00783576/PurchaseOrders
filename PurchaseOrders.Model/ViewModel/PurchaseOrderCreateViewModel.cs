using PurchaseOrders.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PurchaseOrders.Model.ViewModel
{
    public class PurchaseOrderCreateViewModel
    {
        [Required]
        public decimal Amount { get; set; }
        [DataType(DataType.Currency)]
        [Required]
        public decimal Total { get; set; }
        public Product SelectedProduct { get; set; }
        public SelectProductViewModel AvailableProducts { get; set; }
    }
}
