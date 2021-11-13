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
        BasketViewModel basketViewModel;

        public BasketController(IBasketService basketService)
        {
            BasketService = basketService;
        }
        public ActionResult ConfirmTheBasket()
        {
            object myBasket = Session["sepet"];
            object myCustomer = Session["User"];
            if (myBasket != null && myCustomer != null && (myBasket as List<Product>).Count > 0)
            {
                List<Product> products = myBasket as List<Product>;
                bool result = BasketService.ConfirmToBasket(products, Customer.ConvertToCustomer(myCustomer as PocoCustomer));
                return View();
            }
            //is valid check
            return RedirectToAction("Login", "Customer");
        }

    }
}
