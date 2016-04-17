using PurchaseOrders.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders.Model.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> List { get; }
        void Add(Product entity);
        void Delete(Product entity);
        void Update(Product entity);
        Product FindById(int Id);
    }
}
