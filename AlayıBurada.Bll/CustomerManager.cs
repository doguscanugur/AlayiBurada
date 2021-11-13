using AlayıBurada.Dal.Abstract;
using AlayıBurada.Entities.Models;
using AlayıBurada.Entities.PocoModel;
using AlayıBurada.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlayıBurada.Bll
{
    public class CustomerManager : GenericManager<Customer>, ICustomerService
    {
        ICustomerRepository customerRepository;

        public CustomerManager(ICustomerRepository customerRepository) : base(customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public PocoCustomer CustomerLogin(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName.Trim()))
            {
                throw new Exception("You have to fill User Name field.");
            }
            if (string.IsNullOrEmpty(password.Trim()))
            {
                throw new Exception("You have to fill Password field.");
            }
            var pass = new ToPasswordRepository().Sha512(password);
            var user = customerRepository.CustomerLogin(userName, pass);
            if (user == null)
            {
                throw new Exception("User Name or Password is wrong.");
            }
            else
            {
                return new PocoCustomer()
                {
                    CustomerId = user.CustomerId,
                    CustomerName = user.CustomerName,
                    CustomerEmail = user.CustomerEmail,
                    CustomerUserName = user.CustomerUserName,
                };
            }
        }
    }
}