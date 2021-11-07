using AlayıBurada.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlayıBurada.Dal.Abstract
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Customer CustomerLogin(string userName, string password);
    }
}
