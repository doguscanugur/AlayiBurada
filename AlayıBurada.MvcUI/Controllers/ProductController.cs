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
            var model = ProductService.GetProductsByProductId(id);
            PocoCustomer c = (PocoCustomer)Session["User"];
           
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