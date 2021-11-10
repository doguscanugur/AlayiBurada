using AlayıBurada.Interfaces;
using AlayıBurada.MvcUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlayıBurada.MvcUI.Controllers {
    public class BasketController : Controller {
        IBasketService BasketService;

        public BasketController (IBasketService basketService) {
            BasketService = basketService;
        }


        public ActionResult ConfirmTheBasket (BasketViewModel basketViewModel) {




            if (ModelState.IsValid) {
                var basket = BasketService.ConfirmToBasket(basketViewModel.ProductId, basketViewModel.CustomerId);

                return View(basketViewModel);

            }
            else {
                return RedirectToAction("Login", "Customer");
            }


        }



    }
}
}