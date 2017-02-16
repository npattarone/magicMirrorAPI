namespace SmartRetail.MagicMirror.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            webpages_File = new HashSet<webpages_File>();
        }

        [Key]
        public int IdProduct { get; set; }

        [Required]
        [StringLength(10)]
        public string ExternalCode { get; set; }

        public int IdProductModel { get; set; }

        public int IdSize { get; set; }

        public int IdColor { get; set; }

        public bool deleted { get; set; }

        public int op { get; set; }

        public DateTime stamp { get; set; }

        [StringLength(13)]
        public string ProductEPC { get; set; }

        public virtual Color Color { get; set; }

        public virtual ProductModel ProductModel { get; set; }

        public virtual Size Size { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<webpages_File> webpages_File { get; set; }
    }
}
