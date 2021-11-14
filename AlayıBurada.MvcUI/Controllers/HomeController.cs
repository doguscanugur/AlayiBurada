using AlayıBurada.Entities.Models;
using AlayıBurada.Interfaces;
using AlayıBurada.MvcUI.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlayıBurada.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        ICategoryService CategoryService;
        IProductService ProductService;

        public HomeController(ICategoryService categoryService, IProductService productService)
        {
            CategoryService = categoryService;
            ProductService = productService;
        }
        public ActionResult GetCategories(int? page)
        {
            var model = ProductService.GetAll().ToPagedList(page ?? 1, 6);
            return View(model);
        }
        public PartialViewResult GetCategoryListToLeftSide()
        {
            var model = CategoryService.GetAll();
            return PartialView(model);
        }
        public ActionResult AddToCart(int id)
        {
            Product model = ProductService.GetProduct(id);


            if (Session["sepet"] == null)
                Session["sepet"] = new List<Product>();

            if (model != null)
                ((List<Product>)Session["sepet"]).Add(model);
            return PartialView((List<Product>)Session["sepet"]);
        }
    }
}