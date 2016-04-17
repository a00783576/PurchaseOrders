using PurchaseOrders.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders.Model.Repository
{
    public interface IProductTypeRepository
    {
        IEnumerable<ProductType> List { get; }
        void Add(ProductType entity);
        void Delete(ProductType entity);
        void Update(ProductType entity);
        ProductType FindById(int Id);
    }
}
