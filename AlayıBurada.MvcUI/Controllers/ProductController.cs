using AlayıBurada.Bll;
using AlayıBurada.Dal.Concrete.EntityFramework.Repository;
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
    public class ProductController : Controller
    {
        IProductService ProductService;
        ICommentService CommentService;
        public ProductController(IProductService productService, ICommentService commentService)
        {
            ProductService = productService;
            CommentService = commentService;
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

        public ActionResult SeeDetails(int id)
        {
            Product product = ProductService.Get(id);
            List<Comment> comments = CommentService.GetComments(product);
            ViewBag.commentCount = comments.Count;

            CommentProductViewModel cpModel = new CommentProductViewModel()
            {
                Product = product,
                Comments = comments
            };

            return View(cpModel);
        }


    }
}