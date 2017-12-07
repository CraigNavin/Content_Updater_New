using DatabaseLayer;
using ProductRepository;
using ProductsApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductsApi.Controllers
{
    public class ProductController : ApiController
    {
        IProductRepository ProdRepo = new IProductRepository(new ProdDB());

        [HttpGet]
        [Route("api/Products")]
        public IEnumerable<Product> getAllProdcuts()
        {
           
            var products = new IProductRepository(new ProdDB()).getProducts().Select(prod => new Product()
            {
                ID = prod.ID,
                Product_Name = prod.Product_Name,
                Product_Description = prod.Product_Description,
                Ean = prod.Ean,
                ExpectedRestock = prod.ExpectedRestock,
                BrandId = prod.BrandId,
                BrandName = prod.BrandName,
                CategoryId = prod.CategoryId,
                CategoryName = prod.CategoryName
            });

            return products;
        }


        [HttpGet]
        [Route("api/Products")]
        public IEnumerable<Product> getProductByBrandId(int Brandid)
        {
            var products = new IProductRepository(new ProdDB()).getProductsByBrandId(Brandid).Select(prod => new Product()
            {
                ID = prod.ID,
                Product_Name = prod.Product_Name,
                Product_Description = prod.Product_Description,
                Ean = prod.Ean,
                ExpectedRestock = prod.ExpectedRestock,
                BrandId = prod.BrandId,
                BrandName = prod.BrandName,
                CategoryId = prod.CategoryId,
                CategoryName = prod.CategoryName

            });
            return products;
        }


        [HttpGet]
        [Route("api/Products")]
        public IEnumerable<Product> getProductByCatId(int Catid)
        {
            var products = new IProductRepository(new ProdDB()).getProductsByCatId(Catid).Select(prod => new Product()
            {
                ID = prod.ID,
                Product_Name = prod.Product_Name,
                Product_Description = prod.Product_Description,
                Ean = prod.Ean,
                ExpectedRestock = prod.ExpectedRestock,
                BrandId = prod.BrandId,
                BrandName = prod.BrandName,
                CategoryId = prod.CategoryId,
                CategoryName = prod.CategoryName

            });
            return products;
        }

        [HttpGet]
        [Route("api/Products")]
        public IEnumerable<Product> getProductByTerm(string term)
        {
            var products = new IProductRepository(new ProdDB()).getProductsByString(term).Select(prod => new Product()
            {
                ID = prod.ID,
                Product_Name = prod.Product_Name,
                Product_Description = prod.Product_Description,
                Ean = prod.Ean,
                ExpectedRestock = prod.ExpectedRestock,
                BrandId = prod.BrandId,
                BrandName = prod.BrandName,
                CategoryId = prod.CategoryId,
                CategoryName = prod.CategoryName

            });
            return products;
        }

        [HttpGet]
        [Route("api/Products")]
        public IEnumerable<Product> getProductByMaxPrice(double MaxPrice)
        {
            var products = new IProductRepository(new ProdDB()).getProductsMaxPrice(MaxPrice).Select(prod => new Product()
            {
                ID = prod.ID,
                Product_Name = prod.Product_Name,
                Product_Description = prod.Product_Description,
                Ean = prod.Ean,
                ExpectedRestock = prod.ExpectedRestock,
                BrandId = prod.BrandId,
                BrandName = prod.BrandName,
                CategoryId = prod.CategoryId,
                CategoryName = prod.CategoryName

            });
            return products;
        }

        [HttpGet]
        [Route("api/Products")]
        public IEnumerable<Product> getProductByMinPrice(double MinPrice)
        {
            var products = new IProductRepository(new ProdDB()).getProductsMinPrice(MinPrice).Select(prod => new Product()
            {
                ID = prod.ID,
                Product_Name = prod.Product_Name,
                Product_Description = prod.Product_Description,
                Ean = prod.Ean,
                ExpectedRestock = prod.ExpectedRestock,
                BrandId = prod.BrandId,
                BrandName = prod.BrandName,
                CategoryId = prod.CategoryId,
                CategoryName = prod.CategoryName

            });
            return products;
        }
    }
}
