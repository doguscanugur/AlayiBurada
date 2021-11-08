using AlayıBurada.Dal.Abstract;
using AlayıBurada.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlayıBurada.Dal.Concrete.EntityFramework.Repository
{
    public class EfCustomerRepository : EfGenericRepository<Customer>, ICustomerRepository
    {
        public EfCustomerRepository() : base()
        {

        }
        public Customer CustomerLogin(string userName, string password)
        {
            return context.Customer.Where(x => x.CustomerUserName == userName && x.CustomerPassword == password).FirstOrDefault(); //Singleordefault?
        }
    }
}
