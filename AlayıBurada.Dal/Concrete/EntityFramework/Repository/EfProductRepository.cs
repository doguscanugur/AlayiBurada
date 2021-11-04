using AlayıBurada.Dal.Abstract;
using AlayıBurada.Dal.Concrete.EntityFramework.Context;
using AlayıBurada.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlayıBurada.Dal.Concrete.EntityFramework.Repository
{
    public class EfProductRepository : EfGenericRepository<Product>, IProductRepository
    {
        
        public EfProductRepository()
        {
            context = new AlayıBuradaContext();
        }
        
        
        public List<Product> ProductList(int catagoriId)
        {
            return context.Product.Where(x => x.CategoryId == catagoriId).ToList();
        }
    }
}
