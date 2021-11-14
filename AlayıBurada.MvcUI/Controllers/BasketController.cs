using AlayıBurada.Entities.Models;
using AlayıBurada.Entities.PocoModel;
using AlayıBurada.Interfaces;
using AlayıBurada.MvcUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlayıBurada.MvcUI.Controllers
{
    public class BasketController : Controller
    {
        IBasketService BasketService;

        public BasketController(IBasketService basketService)
        {
            BasketService = basketService;
        }
        public ActionResult ConfirmTheBasket()
        {
            object productsInBasket = Session["sepet"];
            object myCustomer = Session["User"];
            if (productsInBasket != null && myCustomer != null && (productsInBasket as List<Product>).Count > 0)
            {
                List<Product> products = productsInBasket as List<Product>;
                bool result = BasketService.ConfirmToBasket(products, Customer.ConvertToCustomer(myCustomer as PocoCustomer));
                Session["sepet"] = null;
                return View();
            }
            //is valid check
            return RedirectToAction("Login", "Customer");
        }

        public ActionResult DeleteProduct(int id)
        {
            object productsInBasket = Session["sepet"];
            foreach (Product product in (List<Product>)productsInBasket)
            {
                if (product.ProductId == id)
                {
                    ((List<Product>)productsInBasket).Remove(product);
                    break;
                }
            }

            return RedirectToAction("GetCategories", "Home");
        }

        public ActionResult CleanBasket()
        {
            Session["sepet"] = null;
            return RedirectToAction("GetCategories", "Home");
        }

    }
}
