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
    public class ProductManager:GenericManager<Product>,IProductService
    {
        IProductRepository productRepository;

        public ProductManager(IProductRepository productRepository):base (productRepository)
        {
            this.productRepository = productRepository;
        }

        public List<Product> ProductList(int catagoriId)
        {
            return productRepository.ProductList(catagoriId);   
        }
    }
}
