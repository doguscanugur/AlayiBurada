namespace AlayıBurada.Entities.Models
{
    using AlayıBurada.Entities.PocoModel;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Basket = new HashSet<Basket>();
            Comment = new HashSet<Comment>();
        }

        public int CustomerId { get; set; }

        public int AddressId { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerUserName { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerEmail { get; set; }

        [Required]
        [StringLength(200)]
        public string CustomerPassword { get; set; }

        public bool CustomerStatus { get; set; }

        public virtual Address Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Basket> Basket { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }

        public static Customer ConvertToCustomer(PocoCustomer pocoCustomer)
        {
            return new Customer()
            {
                CustomerId = pocoCustomer.CustomerId,
                CustomerEmail = pocoCustomer.CustomerEmail,
                CustomerName = pocoCustomer.CustomerName,
                CustomerUserName = pocoCustomer.CustomerUserName
            };
        }
    }
}
