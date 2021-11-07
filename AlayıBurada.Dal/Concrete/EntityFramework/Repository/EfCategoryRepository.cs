using AlayıBurada.Dal.Abstract;
using AlayıBurada.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlayıBurada.Dal.Concrete.EntityFramework.Repository
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryRepository
    {
        public EfCategoryRepository(): base()
        {

        }

        public List<Category> GetAllCategories()
        {
            return context.Category.Where(x => x.CategoryStatus == true).ToList();
        }
    }
}
