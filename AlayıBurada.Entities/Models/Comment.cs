namespace AlayıBurada.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public int CommentId { get; set; }

        public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string CommentTitle { get; set; }

        [Required]
        [StringLength(200)]
        public string CommentDescription { get; set; }

        public bool? CommentStatus { get; set; }

        public int ProductId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Product Product { get; set; }
    }
}
