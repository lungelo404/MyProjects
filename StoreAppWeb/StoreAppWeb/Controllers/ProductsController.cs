using StoreAppWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace StoreAppWeb.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products").Result;

            IEnumerable<ProductModelView> productModelViews = new List<ProductModelView>();

            productModelViews = response.Content.ReadAsAsync<IEnumerable<ProductModelView>>().Result;

            ViewBag.Products = productModelViews;
             
            return View();
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(ProductModelView product)
        {
            try
            {

                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Products", product).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Account successfully added.";
                }
                else
                {
                    TempData["Error"] = "Account number already exists.";
                }
            //    return RedirectToAction("Details", "Person", new { id = product.ProductId });
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
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

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
