namespace MySite.Areas.Data_Access.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        [Key]
        [Column("ID Bill", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Bill { get; set; }

        [Key]
        [Column("ID Customer", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Customer { get; set; }

        [Key]
        [Column("ID Product", Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Product { get; set; }

        [Key]
        [Column("ID Employee", Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Employee { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public int? Total { get; set; }

        public int? Quantity { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Product Product { get; set; }
    }
}
