using System.Collections;
using SmartRetail.MagicMirror.Data.Interfaces;
using SmartRetail.MagicMirror.Data.Repositories;
using System.Web.Http;
using SmartRetail.MagicMirror.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using SmartRetail.MagicMirror.Data;
using Microsoft.Ajax.Utilities;

namespace SmartRetail.MagicMirror.MVC.Controllers
{
    public class ProductController : ApiController
    {
        static readonly IProductRepository repository = new ProductRepository();
        static readonly IProductModelRepository repositoryModel = new ProductModelRepository();
        static readonly IColorRepository repositoryColor = new ColorRepository();

        [HttpGet]
        public IEnumerable GetAllProducts()
        {
            return repository.GetAll();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var product = repository.Get(id);
            var relatedProductModel = repositoryModel.Get(product.IdProductModel);

            var model = new Models.ProductModel();

            model.Description = product.ProductModel.Description;
            model.ExternalCode = product.ProductModel.ExternalCode;
            model.Price = 458;
            model.Stock = 3;
            model.Colors = new List<ColorModel>();
            model.Sizes = new List<SizeModel>();
            model.RelatedProductModel= new List<RelatedProductThumbnailModel>();

            #region Colors

            foreach (var prod in relatedProductModel.Product)
            {
                if (prod.webpages_File.Any())
                {
                    var colorProduct = new ColorModel
                    {
                        Description = prod.Color.Description.Trim(),
                        ExternalCode = prod.Color.ExternalCode.Trim(),
                        ImagesBase64 = new List<ImageModel>(),
                        Style = string.Empty
                    };

                    foreach (var img in prod.webpages_File)
                    {
                        var image64 = new ImageModel
                        {
                            Name = img.FileName,
                            MimeType = img.MimeType,
                            Base64 = "data:" + img.MimeType + ";base64," + Convert.ToBase64String(img.FileData)
                        };

                        colorProduct.ImagesBase64.Add(image64);
                    }

                    model.Colors.Add(colorProduct);
                }
            }

            model.Colors.First().Default = true; // TODO: Configurar desde Administración

            #endregion

            #region Sizes

            foreach (var prod in relatedProductModel.Product.DistinctBy(p => p.IdSize))
            {
                var sizeModel = new SizeModel()
                {
                    Description = prod.Size.Description,
                    ExternalCode = prod.Size.ExternalCode
                };

                model.Sizes.Add(sizeModel);
            }

            #endregion

            #region RelatedProducts

            foreach (var rel in relatedProductModel.RelatedProducts)
            {
                var defaultProduct = repository.GetDefaultThumbnailByProductModel(rel.IdProductModel);
                var defaultImage = defaultProduct?.webpages_File.FirstOrDefault();

                var relatedProduct = new RelatedProductThumbnailModel
                {
                    Description = rel.Description,
                    ExternalCode = rel.ExternalCode,
                    Price = 0,
                    DefaultImageBase64 = "data:" + defaultImage.MimeType + ";base64," + Convert.ToBase64String(defaultImage.FileData)
                };

                model.RelatedProductModel.Add(relatedProduct);
            }

            #endregion

            return this.Ok(model);
        }

        
    }
}
