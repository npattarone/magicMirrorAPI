using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartRetail.MagicMirror.SignalR.API.Models
{
    public class ProductModel
    {
        [JsonProperty("id")]
        public string  Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("code")]
        public string ExternalCode { get; set; }

    }
}