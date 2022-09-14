using StoreAppWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace StoreAppWeb.Controllers
{
    public class ShoppingController : Controller
    {
        // GET: Shopping
        public ActionResult Index()
        {

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products").Result;

            IEnumerable<ProductModelView> productModelViews = new List<ProductModelView>();

            productModelViews = response.Content.ReadAsAsync<IEnumerable<ProductModelView>>().Result;

            ViewBag.Products = productModelViews;

            return View();
        }

        public ActionResult AddtoCart(int productId, string url)
        {
            List<ShoppingModelView> cart = new List<ShoppingModelView>();

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products/" + productId).Result;

            IEnumerable<ProductModelView> productModelViews = new List<ProductModelView>();

            productModelViews = response.Content.ReadAsAsync<IEnumerable<ProductModelView>>().Result;

            ViewBag.Products = productModelViews;
            productId = 1;
            productModelViews.FirstOrDefault(x => x.ProductId == productId);

            ProductModelView product = new ProductModelView();



            if (Session["cart"] == null)
            {
                product = productModelViews.FirstOrDefault(x => x.ProductId == productId);
                cart.Add(new ShoppingModelView()
                {
                    product = product,
                    Qauntity = 1

                }); ;
            }
            else
            {
                cart = (List<ShoppingModelView>)Session["cart"];
                var count = cart.Count();
                product = productModelViews.FirstOrDefault(x => x.ProductId == productId);

                for(int i = 0; i < count; i++)
                {
                    if(cart[i].product.ProductId == productId)
                    {
                        int prevQty = cart[i].Qauntity;
                        cart.Remove(cart[i]);
                        cart.Add(new ShoppingModelView()
                        {
                            product = product,
                            Qauntity  = prevQty + 1
                        }
                       );
                        break;

                    }
                    else
                    {
                        var prd = cart.Where(x => x.product.ProductId == productId).FirstOrDefault();
                        if(prd == null)
                        {
                            cart.Add(new ShoppingModelView()
                            {
                                product = product,
                                Qauntity =  1
                            });
                        }

                    }
                }



            }
            Session["cart"] = cart;

            return View(url);
        }


        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult CheckoutDetails()
        {
            return View();
        }
    }
}