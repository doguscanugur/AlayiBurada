using AlayıBurada.Entities.Models;
using AlayıBurada.Entities.PocoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlayıBurada.Interfaces
{
    public interface ICustomerService:IGenericService<Customer>
    {
        //USER Islemleri
        PocoCustomer CustomerLogin(string userName, string password);
        //void AddCustomer(PocoCustomer customer);

    }
}
