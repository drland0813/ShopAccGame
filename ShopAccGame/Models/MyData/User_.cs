namespace ShopAccGame.Models.MyData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User_()
        {
            Payments = new HashSet<Payment>();
        }

        public int user_id { get; set; }

        [Required]

        [StringLength(150)]
        public string fullname { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(40)]
        public string password { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(12)]
        public string phone { get; set; }

        public DateTime? date_birth { get; set; }

        public int? gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime? create_day { get; set; }

        public int user_role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
