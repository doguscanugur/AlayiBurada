using AlayıBurada.Entities.Models;
using AlayıBurada.Interfaces;
using AlayıBurada.MvcUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlayıBurada.MvcUI.Controllers {
    public class AdminController : Controller {
        IProductService productService;
        ICustomerService customerService;
        IBasketService basketService;
        IAdminService adminService;
        ICategoryService categoryService;

        public AdminController (IProductService productService, ICustomerService customerService, IBasketService basketService, IAdminService adminService, ICategoryService categoryService) {
            this.productService = productService;
            this.customerService = customerService;
            this.basketService = basketService;
            this.adminService = adminService;
            this.categoryService = categoryService;
        }


        //[Authorize()]
        [HttpGet]
        public ActionResult AdminLoginPage () {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLoginPage (AdminViewModel adminViewModel) {

            try {

                if (ModelState.IsValid) {
                    var admin = adminService.AdminLogin(adminViewModel.AdminUserName, adminViewModel.AdminPassword);
                    if (admin != null) {
                        Session["Admin"] = admin;
                        return RedirectToAction("AdminMainPage", "Admin");
                    }
                }
                else {
                    return View(adminViewModel);
                }



            }
            catch (Exception error) {

                ModelState.AddModelError("", error.Message);
                return View(adminViewModel);
            }
            return View(adminViewModel);


        }

        public ActionResult AdminMainPage () { //Admin başarılı giriş yaptığında karşısına çıkacak olan sayfa
            if (Session["Admin"] != null) {
                return View();
            }
            return View("AdminLoginPage", "Admin");
        }

        public PartialViewResult AdminOperationsListToLeftSide () {
            return PartialView();
        }

        //CRUD İŞLEMLERİ//

        //KULLANICI İŞLEMLERİ//
        public ActionResult ListOfCustomers () { //Müşterileri Listele

            List<Customer> customers = customerService.GetAll();
            return View(customers);
        }

        [HttpGet]
        public ActionResult AddCustomer () {


            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer (Customer customer) { //Müşteri ekle
            customerService.Add(customer);
            return View();
        }


        public ActionResult DeleteCustomer (int id) { //id ye göre müşteri sil

            customerService.Remove(id);
            return RedirectToAction("ListOfCustomers");
        }


        [HttpGet]
        public ActionResult UpdateCustomer (int id) {

            var model = customerService.Get(id);
            if (model == null) {
                HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateCustomer (Customer customer) { //Müşteri güncelle

            customerService.Update(customer);
            return View();
        }

        ////////////////////////////////// ürün işlemleri ///////////////////////////////////////

        public ActionResult ListOfProducts () { //Ürünleri Listele

            List<Product> products = productService.GetAll();
            return View(products);
        }

        [HttpGet]
        public ActionResult AddProduct () {

            var model = new CategoryProductViewModel() {
                CategoryList = categoryService.GetAll().ToList()

            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddProduct (Product product) { //Ürün ekle
            productService.Add(product);
            return RedirectToAction("ListOfProducts");
        }


        public ActionResult DeleteProduct (int id) { //id ye göre ürün sil

            productService.Remove(id);

            return RedirectToAction("ListOfProducts");
        }

        [HttpGet]
        public ActionResult UpdateProduct (int id) {

            var model = new CategoryProductViewModel() {
                Product = productService.Get(id),
                CategoryList = categoryService.GetAll()
            };

            //var model = productService.Get(id);
            //if (model == null) {
            //    HttpNotFound();
            //}
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateProduct (Product product) { //Ürün güncelle

            var model = new CategoryProductViewModel() {
                Product = productService.Update(product),
                CategoryList = categoryService.GetAll()
            };
            return View(model);
        }

        public ActionResult ListAllOrders () { // siparişlerin hepsini getir
            List<Basket> baskets = basketService.GetAll();
            return View(baskets);
        }

        public ActionResult DeleteOrder (int id) {

            basketService.Remove(id);
            return RedirectToAction("ListAllOrders");
        }
    
    }
}