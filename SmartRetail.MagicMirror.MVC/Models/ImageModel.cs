using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartRetail.MagicMirror.MVC.Models
{
    public class ImageModel
    {
        public string Base64 { get; set; }

        public string Name { get; set; }

        public string MimeType { get; set; }

        public bool Default { get; set; }
    }
}