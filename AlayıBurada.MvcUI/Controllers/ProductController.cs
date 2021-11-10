using AlayıBurada.Bll;
using AlayıBurada.Dal.Concrete.EntityFramework.Repository;
using AlayıBurada.Entities.Models;
using AlayıBurada.Entities.PocoModel;
using AlayıBurada.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlayıBurada.MvcUI.Controllers
{
    public class ProductController : Controller
    {
        //IProductService productService = new ProductManager(new EfProductRepository());
        IProductService ProductService;
        public ProductController(IProductService productService)
        {
            ProductService = productService;
        }

        

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProduct(int id)
        {
            var model = ProductService.GetProductsByCategoryId(id);

            return View(model);
        }

        public PartialViewResult GetProductById(int id)
        {
            var userModel = ProductService.GetProductsByProductId(id);
            PocoCustomer c = (PocoCustomer)Session["User"];
           
            return PartialView(userModel);
        }

        public ActionResult AddToCart(int id)
        {
            int total = 0;
             Product model = ProductService.GetProduct(id);
            

            if (Session["sepet"] == null)
                Session["sepet"] = new List<Product>();

            if (model != null)
                ((List<Product>)Session["sepet"]).Add(model);

            foreach (var item in (List<Product>)Session["sepet"])
            {
                total += item.ProductPrice;
            }
            ViewBag.total = total;
            return PartialView((List<Product>)Session["sepet"]);
        }       


    }
}