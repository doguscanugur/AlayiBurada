using AlayıBurada.Dal.Abstract;
using AlayıBurada.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlayıBurada.Dal.Concrete.EntityFramework.Repository
{
    public class EfCommentRepository : EfGenericRepository<Comment>, ICommentRepository
    {
        public EfCommentRepository() : base()
        {

        }
        public List<Comment> GetComments(Product product)
        {
            return context.Comment.Where(x => x.ProductId == product.ProductId && x.CommentStatus == true).ToList();
        }
    }
}
