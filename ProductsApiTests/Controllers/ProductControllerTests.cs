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
    }
}