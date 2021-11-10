using AlayıBurada.Dal.Abstract;
using AlayıBurada.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlayıBurada.Dal.Concrete.EntityFramework.Repository {
    public class EfBasketRepository : EfGenericRepository<Basket>, IBasketRepository {
        public EfBasketRepository () :base() {

        }

        public Basket ConfirmToBasket (int productId, int customerId) {

            return context.Basket.Where(x => x.ProductId == productId && x.CustomerId == customerId).FirstOrDefault();
        }
    }
}
