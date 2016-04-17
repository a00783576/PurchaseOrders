using PurchaseOrders.Model.Domain;
using PurchaseOrders.Model.Repository;
using PurchaseOrders.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurchaseOrdersMVC.Controllers
{
    public class PurchaseOrderController : Controller
    {
        IPurchaseOrderRepository _purchaseOrderRepository;
        ICategoryRepository _categoryRepository;
        IProductRepository _productRepository;

        public PurchaseOrderController(IPurchaseOrderRepository purchaseOrderRepository,
            ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            this._purchaseOrderRepository = purchaseOrderRepository;
            this._categoryRepository = categoryRepository;
            this._productRepository = productRepository;
        }

        // GET: PurchaseOrder
        public ActionResult Index(int idCategory = 0)
        {
            var purchaseOrders = new PurchaseOrderViewIndexModel();
            purchaseOrders.Categories = new SelectCategoryViewModel();
            purchaseOrders.PurchaseOrders = new List<PurchaseOrderViewModel>();

            try
            {
                //get categories
                var categoriesQuery = this._categoryRepository.List.Select(c => new SelectListItem
                {
                    Value = c.IdCategory.ToString(),
                    Text = c.Description,
                    Selected = c.IdCategory == idCategory
                });

                //generate the select category view model
                purchaseOrders.Categories = new SelectCategoryViewModel
                {
                    List = categoriesQuery.AsEnumerable()
                };

                //get purchase orders by category
                this._purchaseOrderRepository.FindByCategory(idCategory)
                    .ToList()
                    .ForEach(result =>
                    {
                        var viewModel = new PurchaseOrderViewModel
                        {
                            Description = result.Key.Description,
                            IdOrder = result.Value.IdOrder,
                            OrderDate = result.Value.OrderDate,
                            SupplierName = result.Value.SupplierName
                        };
                        purchaseOrders.PurchaseOrders.Add(viewModel);
                    });

                //set category id
                purchaseOrders.Categories.IdCategory = idCategory;
            }
            catch (Exception ex)
            {
                //log error
            }

            return View(purchaseOrders);
        }

        // GET: PurchaseOrder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PurchaseOrder/Create
        public ActionResult Create()
        {
            var purchaseOrders = new PurchaseOrderCreateViewModel();

            try
            {
                //get categories
                var productsQuery = this._productRepository.List.Select(c => new SelectListItem
                {
                    Value = c.IdProduct.ToString(),
                    Text = c.Description
                });

                //generate the select product view model
                purchaseOrders.AvailableProducts = new SelectProductViewModel
                {
                    List = productsQuery.AsEnumerable()
                };
            }
            catch (Exception ex)
            {

            }

            return View(purchaseOrders);
        }

        // POST: PurchaseOrder/Create
        [HttpPost]
        public ActionResult Create(PurchaseOrderCreateViewModel order)
        {
            try
            {
                var purchaseOrder = new PurchaseOrder
                {
                    OrderDate = DateTime.Now,
                    OrderStatus = true,
                    SupplierName = "Supplier"
                };

                var purchaseOrderDetail = new PurchaseOrderDetail
                {
                    Amount = order.Amount,
                    Comments = "Sold!",
                    IdProduct = order.SelectedProduct.IdProduct,
                    Sequence = 1,
                    Total = order.Total
                };

                this._purchaseOrderRepository.Add(purchaseOrder, purchaseOrderDetail);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PurchaseOrder/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PurchaseOrder/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PurchaseOrder/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var purchaseOrder = new PurchaseOrder
                {
                    IdOrder = id
                };

                _purchaseOrderRepository.Delete(purchaseOrder);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // POST: PurchaseOrder/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var purchaseOrder = new PurchaseOrder
                {
                    IdOrder = id
                };

                _purchaseOrderRepository.Delete(purchaseOrder);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
