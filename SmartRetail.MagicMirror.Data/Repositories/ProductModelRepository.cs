using SmartRetail.MagicMirror.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRetail.MagicMirror.Data
{
    public class ProductModelRepository : IProductModelRepository
    {
        SmartRetailContext context = new SmartRetailContext();

        public ProductModel Get(int id)
        {
            return context.ProductModel.Find(id);
        }

        public IList<ProductModel> GetByIdProduct(int id)
        {
            return context.Product
                .Where(pm => pm.IdProduct == id)
                .Select(pm => pm.ProductModel).ToList();
        }

        public IList<ProductModel> GetAll()
        {
            return context.ProductModel.ToList();
        }
    }
}
