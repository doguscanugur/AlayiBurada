using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlayıBurada.Entities.PocoModel
{
    [NotMapped]
    public class PocoCustomer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerUserName { get; set; }
        public string CustomerEmail { get; set; }

    }
}
