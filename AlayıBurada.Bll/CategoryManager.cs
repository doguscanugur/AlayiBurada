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
    public class CategoryManager : GenericManager<Category>, ICategoryService
    {
        ICategoryRepository categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository):base(categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public List<Category> GetAllCategories()
        {
            return categoryRepository.GetAllCategories();
        }
    }
}
