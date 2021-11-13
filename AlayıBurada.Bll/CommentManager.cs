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
    public class CommentManager : GenericManager<Comment>, ICommentService
    {
        private readonly ICommentRepository commentRepository;

        public CommentManager(ICommentRepository commentRepository) : base(commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public List<Comment> GetComments(Product product)
        {
            return commentRepository.GetComments(product);
        }
    }
}
