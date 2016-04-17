using PurchaseOrders.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders.Model.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> List { get; }
        void Add(Category entity);
        void Delete(Category entity);
        void Update(Category entity);
        Category FindById(int Id);
    }
}
