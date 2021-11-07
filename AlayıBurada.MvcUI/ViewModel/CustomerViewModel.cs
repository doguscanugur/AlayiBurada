using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlayıBurada.MvcUI.ViewModel
{
    public class CustomerViewModel
    {
        [Required(ErrorMessage = "Mandatory"), MinLength(3, ErrorMessage = "Min 4 chars"), MaxLength(12, ErrorMessage = "Max 12 chars")] 
        public string CustomerUserName { get; set; }

        [Required(ErrorMessage ="Mandatory"), MinLength(3, ErrorMessage = "Min 3 chars"), MaxLength(12, ErrorMessage = "Max 12 chars")] 
        public string CustomerPassword { get; set; }


    }
}