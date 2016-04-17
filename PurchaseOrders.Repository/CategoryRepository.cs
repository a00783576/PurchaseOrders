using PurchaseOrders.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchaseOrders.Model.Domain;

namespace PurchaseOrders.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        PurchaseOrdersEntities db = null;

        public CategoryRepository()
        {
            db = new PurchaseOrdersEntities();
        }

        public IEnumerable<Category> List
        {
            get
            {
                var list = new List<Category>();
                db.Categories.ToList().ForEach(item =>
                {
                    var domainObject = new Category
                    {
                        IdCategory = item.IdCategory,
                        Description = item.Description
                    };

                    list.Add(domainObject);
                });
                return list;
            }
        }

        public void Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public Category FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
