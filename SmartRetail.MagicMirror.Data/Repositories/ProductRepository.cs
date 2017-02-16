using System;
using System.Collections.Generic;
using SmartRetail.MagicMirror.Data.Interfaces;
using System.Linq;

namespace SmartRetail.MagicMirror.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        SmartRetailContext context = new SmartRetailContext();

        public Product Get(int id)
        {
            return context.Product.Find(id);
        }

        public Product GetDefaultThumbnailByProductModel(int idProductModel)
        {
            var products = context.Product
                .Where(p => p.IdProductModel == idProductModel);

            return products.FirstOrDefault();
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Product;
        }
    }
}
