using SmartRetail.MagicMirror.Data;
using SmartRetail.MagicMirror.Data.Interfaces;
using System.Collections;
using System.Web.Http;

namespace SmartRetail.MagicMirror.MVC.Controllers
{
    public class ColorController : ApiController
    {
        static readonly IColorRepository repository = new ColorRepository();

        public IEnumerable GetAllColors()
        {
            return repository.GetAll();
        }
    }
}
