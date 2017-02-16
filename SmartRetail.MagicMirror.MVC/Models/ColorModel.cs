using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartRetail.MagicMirror.MVC.Models
{
    public class ColorModel
    {
        public string Description { get; set; }

        public string ExternalCode { get; set; }

        public string Style { get; set; }

        public bool Default { get; set; }

        public IList<ImageModel> ImagesBase64 { get; set; }

    }
}