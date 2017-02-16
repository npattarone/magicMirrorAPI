using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartRetail.MagicMirror.MVC.Models
{
    public class RelatedProductThumbnailModel
    {
        public string Description { get; set; }

        public string ExternalCode { get; set; }

        public decimal Price { get; set; }

        public string DefaultImageBase64 { get; set; }
    }
}