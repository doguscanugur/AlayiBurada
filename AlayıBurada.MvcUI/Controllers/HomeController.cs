using AlayıBurada.Entities.Models;
using AlayıBurada.Interfaces;
using AlayıBurada.MvcUI.ViewModel;
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
            this.CategoryService = categoryService;
            this.ProductService = productService;
        }

        // GET: Home
         
        public ActionResult GetCategories()
        {
            //TempData["category-list"] = CategoryService.GetAllCategories();

            //CategoryProductViewModel categoryProductViewModel = new CategoryProductViewModel(); 
            //categoryProductViewModel.CategoryList = CategoryService.GetAllCategories();
            //categoryProductViewModel.ProductList = ProductService.ProductList();
            var model = ProductService.GetAll();
            return View(model);
        }

        public PartialViewResult GetCategoryListToLeftSide()
        {
            //CategoryProductViewModel categoryProductViewModel = new CategoryProductViewModel();
            //categoryProductViewModel.CategoryList = CategoryService.GetAllCategories();
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