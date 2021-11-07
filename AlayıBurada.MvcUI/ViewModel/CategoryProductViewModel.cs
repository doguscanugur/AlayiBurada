using AlayıBurada.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlayıBurada.MvcUI.ViewModel
{
    public class CategoryProductViewModel
    {
        public List<Category> CategoryList { get; set; }
        public List<Product> ProductList { get; set; }
    }
}