﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlayıBurada.Entities.PocoModel {
    
    [NotMapped]
    public class PocoAdmin {

        
        public string AdminUserName { get; set; }  
        public string AdminPassword { get; set; }
    }
}
