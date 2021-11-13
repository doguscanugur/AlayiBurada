using AlayıBurada.Entities.Models;
using AlayıBurada.Entities.PocoModel;
using AlayıBurada.Interfaces;
using System.Web.Mvc;

namespace AlayıBurada.MvcUI.Controllers
{
    public class CommentController : Controller
    {
        ICommentService CommentService;

        public CommentController(ICommentService commentService)
        {
            CommentService = commentService;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddComment(int id)
        {
            ViewBag.productId = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddComment(Comment comment)
        {
            //user null check - commentStatus'u true at
            comment.CommentStatus = true;
            var user = Session["User"];
            if (user == null)
                return RedirectToAction("Login", "Customer");
            int userId = ((PocoCustomer)user).CustomerId;
            comment.CustomerId = userId;
            CommentService.Add(comment);
            return RedirectToAction("SeeDetails/" + comment.ProductId ,"Product");
        }
    }
}