using PurchaseOrders.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchaseOrders.Model.Domain;

namespace PurchaseOrders.Data
{
    public class PurchaseOrderDetailRepository : IPurchaseOrderDetailRepository
    {
        public IEnumerable<PurchaseOrderDetail> List
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(PurchaseOrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(PurchaseOrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public PurchaseOrderDetail FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(PurchaseOrderDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
