using SmartRetail.MagicMirror.Data;
using SmartRetail.MagicMirror.Data.Interfaces;
using System.Collections;
using System.Web.Http;

namespace SmartRetail.MagicMirror.MVC.Controllers
{
    public class ProductModelController : ApiController
    {
        static readonly IProductModelRepository repository = new ProductModelRepository();

        public IEnumerable GetAllProductModels()
        {
            return repository.GetAll();
        }
    }
}
