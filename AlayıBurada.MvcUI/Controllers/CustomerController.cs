using AlayıBurada.Bll;
using AlayıBurada.Entities.Models;
using AlayıBurada.Entities.PocoModel;
using AlayıBurada.Interfaces;
using AlayıBurada.MvcUI.ViewModel;
using System;
using System.Web.Mvc;

namespace AlayıBurada.MvcUI.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerService CustomerService;

        public CustomerController(ICustomerService customerService)
        {
            CustomerService = customerService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(CustomerViewModel customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = CustomerService.CustomerLogin(customer.CustomerUserName, customer.CustomerPassword);
                    if (user != null)
                    {
                        Session["User"] = user;



                        return RedirectToAction("GetCategories", "Home");
                    }
                }
                else
                {
                    return View(customer);
                }
            }
            catch (Exception err)
            {
                ModelState.AddModelError("", err.Message);
                return View(customer);
            }
            return View(customer);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            customer.CustomerStatus = true;
            customer.Address.AddressStatus = true;
            customer.CustomerPassword = new ToPasswordRepository().Sha512(customer.CustomerPassword);
            CustomerService.Add(customer);
            return View("GetCategories", "Home");

        }

        public ActionResult GetLoggedCustomerName()
        {
            PocoCustomer logedCustomer = (PocoCustomer)Session["User"];
            if (logedCustomer != null)
            {
                string loggedUserName = ((PocoCustomer)Session["User"]).CustomerName;
                return Content(loggedUserName);

            }
            return Content(null);
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("GetCategories", "Home");
        }
    }
}