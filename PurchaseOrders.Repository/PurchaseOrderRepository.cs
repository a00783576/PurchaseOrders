using PurchaseOrders.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchaseOrders.Model.Domain;

namespace PurchaseOrders.Data
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        PurchaseOrdersEntities db = null;

        public PurchaseOrderRepository()
        {
            db = new PurchaseOrdersEntities();
        }


        public IEnumerable<PurchaseOrder> List
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(PurchaseOrder entity, PurchaseOrderDetail detail)
        {
            PurchaseOrders item = new PurchaseOrders
            {
                OrderDate = entity.OrderDate,
                OrderStatus = entity.OrderStatus,
                SupplierName = entity.SupplierName,
                PurchaseOrderDetails = new List<PurchaseOrderDetails>()
                {
                    new PurchaseOrderDetails()
                    {
                        Amount = detail.Amount,
                        Comments = detail.Comments,
                        IdProduct = detail.IdProduct,
                        Sequence = detail.Sequence,
                        Total = detail.Total
                    }
                }
            };

            db.CreatePurchaseOrder(item.OrderDate, item.OrderStatus, item.SupplierName,
                detail.Amount, detail.Comments, detail.IdProduct, detail.Sequence, detail.Total);
        }

        public void Delete(PurchaseOrder entity)
        {
            var purchaseOrder = new PurchaseOrders
            {
                IdOrder= entity.IdOrder                           
            };

            db.PurchaseOrderDetails
                .Where(pod => pod.IdOrder == entity.IdOrder)
                .ToList()
                .ForEach(pod =>
                {
                    db.PurchaseOrderDetails.Attach(pod);
                    db.PurchaseOrderDetails.Remove(pod);
                });

            db.PurchaseOrders.Attach(purchaseOrder);
            db.PurchaseOrders.Remove(purchaseOrder);
            db.SaveChanges();
        }

        public IDictionary<Product, PurchaseOrder> FindByCategory(int idCategory)
        {
            var dictionary = new Dictionary<Product, PurchaseOrder>();

            if (idCategory != 0)
            {
                db.PurchaseOrders
                    .Join(db.PurchaseOrderDetails, po => po.IdOrder, pod => pod.IdOrder, (po, pod) => new { po, pod })
                    .Join(db.Products, pod => pod.pod.IdProduct, p => p.IdProduct, (pod, p) => new { pod, p })
                    .Join(db.ProductType, p => p.p.IdProductType, pt => pt.IdProductType, (p, pt) => new { p, pt })
                    .Join(db.Categories, pt => pt.pt.IdCategory, c => c.IdCategory, (pt, c) => new { pt, c })
                    .Where(r => r.c.IdCategory == idCategory)
                    .Select(r => new
                    {
                        IdOrder = r.pt.p.pod.po.IdOrder,
                        OrderDate = r.pt.p.pod.po.OrderDate,
                        OrderStatus = r.pt.p.pod.po.OrderStatus,
                        SupplierName = r.pt.p.pod.po.SupplierName,
                        Product = r.pt.p.p
                    })
                    .ToList().ForEach(item =>
                    {
                        var purchaseOrder = new PurchaseOrder
                        {
                            IdOrder = item.IdOrder,
                            OrderDate = item.OrderDate,
                            OrderStatus = item.OrderStatus,
                            SupplierName = item.SupplierName
                        };

                        var product = new Product
                        {
                            IdProduct = item.Product.IdProduct,
                            Amount = item.Product.Amount,
                            Description = item.Product.Description,
                            IdProductType = item.Product.IdProductType,
                            Price = item.Product.Price
                        };

                        dictionary.Add(product, purchaseOrder);
                    });

            }


            return dictionary;
        }

        public PurchaseOrder FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(PurchaseOrder entity)
        {
            throw new NotImplementedException();
        }
    }
}
