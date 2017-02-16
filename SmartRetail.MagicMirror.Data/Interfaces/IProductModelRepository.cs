using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRetail.MagicMirror.Data.Interfaces
{
    public interface IProductModelRepository
    {
        IList<ProductModel> GetAll();

        ProductModel Get(int id);

        IList<ProductModel> GetByIdProduct(int id);
    }
}