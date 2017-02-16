using SmartRetail.MagicMirror.Data;
using SmartRetail.MagicMirror.Data.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartRetail.MagicMirror.MVC.Controllers
{
    public class SizeController : ApiController
    {
        static readonly ISizeRepository repository = new SizeRepository();

        public IEnumerable GetAllSizes()
        {
            return repository.GetAll();
        }
    }
}
