namespace SmartRetail.MagicMirror.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class webpages_File
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public webpages_File()
        {
            Product = new HashSet<Product>();
        }

        [Key]
        public int IdFile { get; set; }

        [Required]
        public byte[] FileData { get; set; }

        [Required]
        [StringLength(255)]
        public string MimeType { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string FileName { get; set; }

        public int op { get; set; }

        public DateTime stamp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
