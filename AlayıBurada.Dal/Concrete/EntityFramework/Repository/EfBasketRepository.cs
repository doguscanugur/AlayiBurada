using AlayıBurada.Dal.Abstract;
using AlayıBurada.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlayıBurada.Dal.Concrete.EntityFramework.Repository
{
    public class EfBasketRepository : EfGenericRepository<Basket>, IBasketRepository
    {
        public EfBasketRepository() : base()
        {

        }

        public bool ConfirmToBasket(int productID, int customerID)
        {
            Basket basket = Add(new Basket { ProductId = productID, CustomerId = customerID });
            return basket == null ? false : true;
        }
    }
}
