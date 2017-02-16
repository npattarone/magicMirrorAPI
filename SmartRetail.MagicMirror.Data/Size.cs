namespace SmartRetail.MagicMirror.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Size")]
    public partial class Size
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Size()
        {
            Product = new HashSet<Product>();
        }

        [Key]
        public int IdSize { get; set; }

        [Required]
        [StringLength(10)]
        public string Description { get; set; }

        [Required]
        [StringLength(10)]
        public string ExternalCode { get; set; }

        public bool deleted { get; set; }

        public int op { get; set; }

        public DateTime stamp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }
    }
}