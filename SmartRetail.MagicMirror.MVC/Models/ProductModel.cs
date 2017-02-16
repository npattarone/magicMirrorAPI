using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartRetail.MagicMirror.MVC.Models
{
    public class ProductModel
    {
        public string Description { get; set; }

        public string LongDescription { get; set; }

        public string ExternalCode { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public IList<ColorModel> Colors{ get; set; }

        public IList<SizeModel> Sizes { get; set; }

        public IList<RelatedProductThumbnailModel> RelatedProductModel { get; set; }

    }
    
}