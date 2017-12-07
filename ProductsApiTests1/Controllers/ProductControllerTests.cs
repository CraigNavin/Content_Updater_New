using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsApi.Controllers;
using ProductsApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApi.Controllers.Tests
{
    [TestClass()]
    public class ProductControllerTests
    {
        ProductController pc = new ProductController();

        [TestMethod()]
        public void getAllProdcutsTest()
        {
            Assert.IsInstanceOfType(pc.getAllProdcuts(), typeof(IEnumerable<Product>));
        }

        [TestMethod()]
        public void getProductByBrandIdTest()
        {
            Assert.IsInstanceOfType(pc.getProductByBrandId(1), typeof(IEnumerable<Product>));
        }

        [TestMethod()]
        public void getProductByCatIdTest()
        {
            Assert.IsInstanceOfType(pc.getProductByCatId(1), typeof(IEnumerable<Product>));
        }

        [TestMethod()]
        public void getProductByTermTest()
        {
            Assert.IsInstanceOfType(pc.getProductByTerm("Sponge"), typeof(IEnumerable<Product>));
        }

        [TestMethod()]
        public void getProductByMaxPriceTest()
        {
            Assert.IsInstanceOfType(pc.getProductByMaxPrice(56.23), typeof(IEnumerable<Product>));
        }

        [TestMethod()]
        public void getProductByMinPriceTest()
        {
            Assert.IsInstanceOfType(pc.getProductByMinPrice(2.65), typeof(IEnumerable<Product>));
        }
    }
}