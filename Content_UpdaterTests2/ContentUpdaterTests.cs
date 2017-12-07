using Microsoft.VisualStudio.TestTools.UnitTesting;
using Content_Updater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;
using ProductRepository;
using System.Net;

namespace Content_Updater.Tests
{
    [TestClass()]
    public class ContentUpdaterTests
    {

        static List<string> urilist = new List<string>() { "http://dodgydealers.azurewebsites.net/api/product", "http://undercutters.azurewebsites.net/api/product" };
        ContentUpdater cu = new ContentUpdater(urilist);
        WebClient client = new WebClient();
        IProductRepository ProdRepo = new IProductRepository(new ProdDB());

        [TestMethod()]
        public void checkforUpdatesTest()
        {
            bool check = cu.checkForUpdates(ProdRepo.getProducts(), cu.getAllproducts());
            Assert.IsInstanceOfType(check,typeof(bool));
        }

        [TestMethod()]
        public void runUpdatesTest()
        {
            List<Product_table2> list = cu.runUpdates(ProdRepo.getProducts(), cu.getAllproducts());
            Assert.IsInstanceOfType(list, typeof(List<Product_table2>));
        }

        [TestMethod()]
        public void getAllproductsTest()
        {
            List<Product_table2> list = cu.getAllproducts();
            Assert.IsInstanceOfType(list,typeof(List<Product_table2>));
        }

        [TestMethod()]
        public void buildlistwcfTest()
        {
            List < Product_table2 > list = cu.buildlistwcf(0);
            Assert.IsInstanceOfType(list,typeof(List<Product_table2>));
        }

        [TestMethod()]
        public void buildListTest()
        {
            client.Headers.Add("Content-Type:application/json");
            client.Headers.Add("Accept:application/json");
            dynamic result = null;
            result = client.DownloadString(urilist.Single());
            //List<Product_table2> list = cu.buildList(result, 0);
            //Assert.IsInstanceOfType(list,typeof(List<Product_table2>));
        }

        [TestMethod()]
        public void insertDataTest()
        {
            cu.insertData(cu.getAllproducts());

            Assert.IsTrue(ProdRepo.getProducts().Count > 0);
        }

        [TestMethod()]
        public void ShowProductTest()
        {
            string result = new ContentUpdater().ShowProduct(new Product_table2 { ID = 1, Product_Name = "Sponge", Product_Description = "Cleaning Sponge", Ean = "4 34324 2342", ExpectedRestock = true, BrandId = 1, BrandName = "Soggy sponge", CategoryId = 1, CategoryName = "Cleaning", Price = 3.56, Original_Price = 5.00 });
            string expected = "Product ID: 1Product name: Sponge Product Desc: Cleaning Sponge Product price 3.56";
            Assert.AreEqual(expected,result);
        }
    }
}