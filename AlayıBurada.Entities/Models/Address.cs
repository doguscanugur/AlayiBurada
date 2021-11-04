namespace AlayıBurada.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Address")]
    public partial class Address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address()
        {
            Customer = new HashSet<Customer>();
        }

        public int AddressId { get; set; }

        [Required]
        [StringLength(50)]
        public string AddressCity { get; set; }

        [Required]
        [StringLength(50)]
        public string AddressDisctrict { get; set; }

        [Required]
        [StringLength(50)]
        public string AddressDescription { get; set; }

        public bool AddressStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customer { get; set; }
    }
}
