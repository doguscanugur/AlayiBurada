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

        public EfProductRepository() : base()
        {
            // Burada context newlemeye gerek yok. yukarıdaki base keywordü ile parent classtaki ctor'u çalıştırdım. orda da contexti newlediğim için burada kullanabileceğim.
            // Böylece sadece generic olarak kullanmak istediğim classları başka repository oluşturmadan kullanabilirim. (ÖRN: SADECE CRUD İŞLEMLERİ OLAN CLASSLAR)
        }

        public List<Product> GetProductsByCategoryId(int id)
        {
            return context.Product.Where(x => x.ProductStatus == true && x.Category.CategoryId == id).ToList();
        }

        public List<Product> ProductList()
        {
            return context.Product.Where(x => x.ProductStatus == true).ToList();
        }
    }
}
