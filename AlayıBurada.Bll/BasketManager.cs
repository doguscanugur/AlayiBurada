using AlayıBurada.Dal.Abstract;
using AlayıBurada.Entities.Models;
using AlayıBurada.Entities.PocoModel;
using AlayıBurada.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlayıBurada.Bll {
    public class BasketManager : GenericManager<Basket>, IBasketService {


        IBasketRepository basketRepository;

        public BasketManager (IBasketRepository basketRepository) : base(basketRepository) {
            this.basketRepository = basketRepository;
        }

        public PocoBasket ConfirmToBasket (int productId, int customerId) {
            if (productId == 0 && customerId == 0) {

                throw new Exception("Purchase failed");
            }
            var basket = basketRepository.ConfirmToBasket(productId, customerId);
            return new PocoBasket {
                CustomerId = basket.CustomerId,
                ProductId = basket.ProductId,

            };
        }
    }
}
