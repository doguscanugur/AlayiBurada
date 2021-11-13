using AlayıBurada.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlayıBurada.MvcUI.ViewModel
{
    public class CommentProductViewModel
    {
        public Product Product { get; set; }
        public List<Comment> Comments { get; set; }

    }
}