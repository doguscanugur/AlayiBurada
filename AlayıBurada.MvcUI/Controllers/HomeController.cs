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
            CategoryProductViewModel categoryProductViewModel = new CategoryProductViewModel(); 
            categoryProductViewModel.CategoryList = CategoryService.GetAllCategories();
            categoryProductViewModel.ProductList = ProductService.ProductList();
            return View(categoryProductViewModel);
        }
        //public ActionResult ProductList()
        //{
        //    var list = ProductService.ProductList();
        //    return View(list);
        //}
    }
}