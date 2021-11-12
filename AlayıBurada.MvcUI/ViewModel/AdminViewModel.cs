using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlayıBurada.MvcUI.ViewModel {
    public class AdminViewModel {

        [Required]
        public string AdminUserName { get; set; }
        [Required]
        public string AdminPassword { get; set; }
    }
}