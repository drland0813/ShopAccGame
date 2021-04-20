namespace ShopAccGame.Models.MyData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Game")]
    public partial class Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Game()
        {
            Accounts = new HashSet<Account>();
        }

        [Key]
        public int game_id { get; set; }

        [Required]
        [StringLength(150)]
        public string game_name { get; set; }

        public int? game_type { get; set; }

        [Required]
        [StringLength(70)]
        public string game_owner { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
