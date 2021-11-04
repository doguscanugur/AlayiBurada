namespace AlayıBurada.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Basket")]
    public partial class Basket
    {
        public int BasketId { get; set; }

        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime BasketDate { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Product Product { get; set; }
    }
}
