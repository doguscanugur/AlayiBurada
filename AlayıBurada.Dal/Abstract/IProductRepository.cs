using AlayıBurada.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlayıBurada.Dal.Abstract
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        List<Product> ProductList();
        List<Product> GetProductsByCategoryId(int id);

    }
}
