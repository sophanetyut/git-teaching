namespace testGitAspNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SaleDetail")]
    public partial class SaleDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SaleId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ProductStockId { get; set; }

        public int SaleQuantity { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal Price { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal RowTotal { get; set; }

        public virtual ProductStock ProductStock { get; set; }

        public virtual Sale Sale { get; set; }
    }
}
