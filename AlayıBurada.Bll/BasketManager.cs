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
    public class BasketManager : GenericManager<Basket>, IBasketService
    {


        IBasketRepository basketRepository;

        public BasketManager(IBasketRepository basketRepository) : base(basketRepository)
        {
            this.basketRepository = basketRepository;
        }

        public bool ConfirmToBasket(List<Product> products, Customer customer)
        {
            bool customerVerified = customer == null || customer.CustomerId == 0;
            bool productsVerified = products == null || products.Count <= 0;
            if (productsVerified && customerVerified)
            {
                return false;
            }
            bool result = false;
            foreach (Product product in products)
            {
                 result=basketRepository.ConfirmToBasket(product.ProductId, customer.CustomerId);
            }
            return result;
        }
    }
}
