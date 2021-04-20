namespace ShopAccGame.Models.MyData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        [Key]
        public int payment_id { get; set; }

        public DateTime? create_day { get; set; }

        public int user_id { get; set; }

        public int account_id { get; set; }

        public virtual Account Account { get; set; }

        public virtual User_ User_ { get; set; }
    }
}
