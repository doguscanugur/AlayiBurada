using AlayıBurada.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlayıBurada.Dal.Abstract
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        List<Comment> GetComments(Product product);

    }
}
