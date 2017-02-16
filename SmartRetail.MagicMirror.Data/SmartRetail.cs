namespace SmartRetail.MagicMirror.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SmartRetailContext : DbContext
    {
        public SmartRetailContext()
            : base("name=SmartRetail")
        {
        }

        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductModel> ProductModel { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<webpages_File> webpages_File { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Color>()
                .Property(e => e.ExternalCode)
                .IsUnicode(false);

            modelBuilder.Entity<Color>()
                .Property(e => e.Style)
                .IsUnicode(false);

            modelBuilder.Entity<Color>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Color)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ExternalCode)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductEPC)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.webpages_File)
                .WithMany(e => e.Product)
                .Map(m => m.ToTable("ProductFiles").MapLeftKey("IdProduct").MapRightKey("IdFile"));

            modelBuilder.Entity<ProductModel>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ProductModel>()
                .Property(e => e.ExternalCode)
                .IsUnicode(false);

            modelBuilder.Entity<ProductModel>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.ProductModel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductModel>()
                .HasMany(e => e.RelatedProducts)
                .WithMany()
                .Map(m => m.ToTable("RelatedProducts").MapLeftKey("IdProductModel").MapRightKey("IdRelatedProductModel"));

            modelBuilder.Entity<Size>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Size>()
                .Property(e => e.ExternalCode)
                .IsUnicode(false);

            modelBuilder.Entity<Size>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Size)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<webpages_File>()
                .Property(e => e.MimeType)
                .IsUnicode(false);

            modelBuilder.Entity<webpages_File>()
                .Property(e => e.FileName)
                .IsUnicode(false);
        }
    }
}
