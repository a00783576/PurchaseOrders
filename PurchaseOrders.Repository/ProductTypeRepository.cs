using PurchaseOrders.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchaseOrders.Model.Domain;

namespace PurchaseOrders.Data
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        public IEnumerable<Model.Domain.ProductType> List
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(Model.Domain.ProductType entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Model.Domain.ProductType entity)
        {
            throw new NotImplementedException();
        }

        public Model.Domain.ProductType FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Model.Domain.ProductType entity)
        {
            throw new NotImplementedException();
        }
    }
}
