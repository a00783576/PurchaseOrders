using PurchaseOrders.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders.Model.Repository
{
    public interface IPurchaseOrderRepository
    {
        IEnumerable<PurchaseOrder> List { get; }
        void Add(PurchaseOrder entity, PurchaseOrderDetail details);
        void Delete(PurchaseOrder entity);
        void Update(PurchaseOrder entity);
        PurchaseOrder FindById(int Id);
        IDictionary<Product, PurchaseOrder> FindByCategory(int idCategory);
    }
}
