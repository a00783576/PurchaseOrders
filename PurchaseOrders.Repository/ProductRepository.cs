using PurchaseOrders.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchaseOrders.Model.Domain;

namespace PurchaseOrders.Data
{
    public class ProductRepository : IProductRepository
    {
        PurchaseOrdersEntities db = null;

        public ProductRepository()
        {
            db = new PurchaseOrdersEntities();
        }

        public IEnumerable<Product> List
        {
            get
            {
                var list = new List<Product>();
                db.Products.ToList().ForEach(item =>
                {
                    var domainObject = new Product
                    {
                        IdProduct = item.IdProduct,
                        Amount = item.Amount,
                        Price = item.Price,
                        IdProductType = item.IdProductType,
                        Description = item.Description
                    };

                    list.Add(domainObject);
                });
                return list;
            }
        }

        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product FindById(int Id)
        {
            
            var item = db.Products.Where(r => r.IdProduct == Id).FirstOrDefault();
            var result = new Product
            {
                Amount = item.Amount,
                Description = item.Description,
                IdProduct = item.IdProduct,
                IdProductType = item.IdProductType,
                Price = item.Price
            };
            return result;
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
