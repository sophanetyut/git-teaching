namespace testGitAspNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductStock")]
    public partial class ProductStock
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductStock()
        {
            SaleDetails = new HashSet<SaleDetail>();
        }

        public long Id { get; set; }

        public int ProductId { get; set; }

        public int ProductSizeId { get; set; }

        public int ProductColorId { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal Cost { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public byte[] Photo { get; set; }

        public int BoxCount { get; set; }

        public virtual Product Product { get; set; }

        public virtual ProductColor ProductColor { get; set; }

        public virtual ProductSize ProductSize { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
