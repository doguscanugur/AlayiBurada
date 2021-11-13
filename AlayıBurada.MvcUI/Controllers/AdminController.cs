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
    public class AdminController : Controller
    {
        IProductService productService;
        ICustomerService customerService;
        IBasketService basketService;
        IAdminService adminService;

        public AdminController(IProductService productService, ICustomerService customerService, IBasketService basketService, IAdminService adminService)
        {
            this.productService = productService;
            this.customerService = customerService;
            this.basketService = basketService;
            this.adminService = adminService;
        }


        [Authorize()]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminLoginPage(AdminViewModel adminViewModel)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    var admin = adminService.AdminLogin(adminViewModel.AdminUserName, adminViewModel.AdminPassword);
                    if (admin != null)
                    {
                        Session["Admin"] = admin;
                        return RedirectToAction("AdminMainPage", "Admin");
                    }
                }
                else
                {
                    return View(adminViewModel);
                }



            }
            catch (Exception error)
            {

                ModelState.AddModelError("", error.Message);
                return View(adminViewModel);
            }
            return View(adminViewModel);


        }

        public ActionResult AdminMainPage()
        { //Admin başarılı giriş yaptığında karşısına çıkacak olan sayfa
            if (Session["Admin"] != null)
            {
                return View();
            }
            return View("AdminLoginPage", "Admin");
        }


        //CRUD İŞLEMLERİ//

        //KULLANICI İŞLEMLERİ//
        public PartialViewResult ListOfCustomers()
        { //Müşterileri Listele

            List<Customer> customers = customerService.GetAll();
            return PartialView(customers);
        }

        public PartialViewResult AddCustomer(Customer customer)
        { //Müşteri ekle
            customerService.Add(customer);
            return PartialView();
        }


        public PartialViewResult DeleteCustomer(int id)
        { //id ye göre müşteri sil

            return PartialView(customerService.Remove(id));
        }

        public PartialViewResult UpdateCustomer(Customer customer)
        { //Müşteri güncelle
            customerService.Update(customer);
            return PartialView();
        }

        ////////////////////////////////// ürün işlemleri ///////////////////////////////////////

        public PartialViewResult ListOfProducts()
        { //Ürünleri Listele

            List<Product> products = productService.GetAll();
            return PartialView(products);
        }

        public PartialViewResult AddProduct(Product product)
        { //Ürün ekle
            productService.Add(product);
            return PartialView();
        }


        public PartialViewResult DeleteProduct(int id)
        { //id ye göre ürün sil

            return PartialView(productService.Remove(id));
        }

        public PartialViewResult UpdateProduct(Product product)
        { //Ürün güncelle
            productService.Update(product);
            return PartialView();
        }

        public PartialViewResult ListAllOrders()
        { // ürünlerin hepsini getir
            basketService.GetAll();
            return PartialView();
        }

        //YAPILACAK


        //public PartialViewResult ListOrdersByCustomer (int id) {


        //}
    }
}