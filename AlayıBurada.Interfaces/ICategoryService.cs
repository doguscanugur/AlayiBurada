using AlayıBurada.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlayıBurada.Interfaces
{
    public interface ICategoryService : IGenericService<Category>
    {
        //Sadece bu entity'e özgü metodlar gelecek.
        List<Category> GetAllCategories();
       
    }
}
