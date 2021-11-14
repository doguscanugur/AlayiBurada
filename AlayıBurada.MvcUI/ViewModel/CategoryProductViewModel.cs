using AlayıBurada.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlayıBurada.MvcUI.ViewModel
{
    public class CategoryProductViewModel
    {
        public IEnumerable<Category> CategoryList { get; set; }
        public Product Product { get; set; }
    }
}