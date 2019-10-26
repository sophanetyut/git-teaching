namespace testGitAspNet.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB : DbContext
    {
        public DB()
            : base("name=DB")
        {
        }

        public virtual DbSet<Commune> Communes { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductColor> ProductColors { get; set; }
        public virtual DbSet<ProductSize> ProductSizes { get; set; }
        public virtual DbSet<ProductStock> ProductStocks { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SaleDetail> SaleDetails { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserHasPermission> UserHasPermissions { get; set; }
        public virtual DbSet<Village> Villages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .HasMany(e => e.UserHasPermissions)
                .WithRequired(e => e.Permission)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductStocks)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.ProductCategory)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<ProductColor>()
                .HasMany(e => e.ProductStocks)
                .WithRequired(e => e.ProductColor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductSize>()
                .HasMany(e => e.ProductStocks)
                .WithRequired(e => e.ProductSize)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductStock>()
                .Property(e => e.Cost)
                .HasPrecision(10, 4);

            modelBuilder.Entity<ProductStock>()
                .Property(e => e.Price)
                .HasPrecision(10, 4);

            modelBuilder.Entity<ProductStock>()
                .HasMany(e => e.SaleDetails)
                .WithRequired(e => e.ProductStock)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sale>()
                .Property(e => e.Tax)
                .HasPrecision(10, 4);

            modelBuilder.Entity<Sale>()
                .Property(e => e.SubTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Sale>()
                .Property(e => e.Discount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Sale>()
                .Property(e => e.TotalDue)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SaleDetail>()
                .Property(e => e.Price)
                .HasPrecision(10, 4);

            modelBuilder.Entity<SaleDetail>()
                .Property(e => e.RowTotal)
                .HasPrecision(10, 4);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Phone1)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Phone2)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.HashCode)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserHasPermissions)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserHasPermission>()
                .Property(e => e.Description)
                .IsUnicode(false);
        }
    }
}
