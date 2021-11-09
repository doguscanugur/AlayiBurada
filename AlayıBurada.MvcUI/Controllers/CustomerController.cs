using AlayıBurada.Bll;
using AlayıBurada.Dal.Concrete.EntityFramework.Repository;
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
            CustomerService.Add(customer);
            return View("GetCategories", "Home");
        }
    }
}