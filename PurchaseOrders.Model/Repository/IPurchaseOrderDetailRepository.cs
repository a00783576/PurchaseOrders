using PurchaseOrders.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders.Model.Repository
{
    public interface IPurchaseOrderDetailRepository
    {
        IEnumerable<PurchaseOrderDetail> List { get; }
        void Add(PurchaseOrderDetail entity);
        void Delete(PurchaseOrderDetail entity);
        void Update(PurchaseOrderDetail entity);
        PurchaseOrderDetail FindById(int Id);
    }
}
