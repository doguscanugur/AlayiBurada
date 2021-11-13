using AlayıBurada.Dal.Abstract;
using AlayıBurada.Entities.Models;
using AlayıBurada.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlayıBurada.Bll
{
    public class ProductManager : GenericManager<Product>, IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductManager(IProductRepository productRepository) : base(productRepository) //Constructur'a geri gönder
        {
            this.productRepository = productRepository;
        }

        public Product GetProduct(int id)
        {
            return productRepository.AddToBasket(id);
        }

        public List<Product> GetProductsByCategoryId(int id)
        {
            return productRepository.GetProductsByCategoryId(id);
        }

        public List<Product> GetProductsByProductId(int id)
        {
            return productRepository.GetProductsByProductId(id);
        }

        public List<Product> ProductList()
        {
            return productRepository.ProductList();
        }


    }
}
