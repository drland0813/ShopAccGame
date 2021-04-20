namespace ShopAccGame.Models.MyData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            Payments = new HashSet<Payment>();
        }

        [Key]
        public int account_id { get; set; }

        public int game_id { get; set; }

        [Required]
        [StringLength(70)]
        public string account_name { get; set; }

        [Required]
        [StringLength(70)]
        public string password { get; set; }

        [Required]
        [StringLength(100)]
        public string account_nickname { get; set; }

        public int rank { get; set; }

        public int level { get; set; }

        public int? champions { get; set; }

        public int? skins { get; set; }

        public int? icons { get; set; }

        public int? chroma { get; set; }

        public int? ward_skins { get; set; }

        public int? emotes { get; set; }

        public int state { get; set; }

        [Column(TypeName = "date")]
        public DateTime? create_day { get; set; }

        public float sale_price { get; set; }

        public virtual Game Game { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
