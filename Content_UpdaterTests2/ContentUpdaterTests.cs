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

        [TestMethod()]
        public void ContentUpdaterTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RunTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void OnTimedEventTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void checkforUpdatesTest()
        {
            List<Product_table2> expected = new List<Product_table2>()
            {
                new Product_table2{ID =1, Product_Name="Sponge",Product_Description="Cleaning Sponge",Ean="4 34324 2342",ExpectedRestock=true, BrandId=1,BrandName="Soggy sponge",CategoryId=1,CategoryName="Cleaning",Price=3.56,Original_Price=5.00},
                new Product_table2{ID=2,Product_Name="Pencil",Product_Description="Hb Pencil",Ean="5 54353 2123",ExpectedRestock=true,BrandId=2,BrandName="Stadt",CategoryId=2,CategoryName="Stationary",Price=2.33,Original_Price=3.00 },
                new Product_table2{ID=3,Product_Name="Glass",Product_Description="HOmeware Glass",Ean="3 34324 2341",ExpectedRestock=false,BrandId=3,BrandName="Homebase",CategoryId=3,CategoryName="Homeware",Price=3.45,Original_Price=5.88 }
            };

            List<Product_table2> oldlist = new List<Product_table2>()
            {
                new Product_table2{ID =1, Product_Name="Sponge",Product_Description="Cleaning Sponge",Ean="4 34324 2342",ExpectedRestock=true, BrandId=1,BrandName="Soggy sponge",CategoryId=1,CategoryName="Cleaning",Price=5.00,Original_Price=5.00},
                new Product_table2{ID=2,Product_Name="Pencil",Product_Description="Hb Pencil",Ean="5 54353 2123",ExpectedRestock=true,BrandId=2,BrandName="Stadt",CategoryId=2,CategoryName="Stationary",Price=3.00,Original_Price=3.00 },
                new Product_table2{ID=3,Product_Name="Glass",Product_Description="HOmeware Glass",Ean="3 34324 2341",ExpectedRestock=false,BrandId=3,BrandName="Homebase",CategoryId=3,CategoryName="Homeware",Price=5.88,Original_Price=5.88 }
            };


            List<Product_table2> newList = new List<Product_table2>()
            {
                new Product_table2{ID =1, Product_Name="Sponge",Product_Description="Cleaning Sponge",Ean="4 34324 2342",ExpectedRestock=true, BrandId=1,BrandName="Soggy sponge",CategoryId=1,CategoryName="Cleaning",Price=3.56,Original_Price=5.00},
                new Product_table2{ID=2,Product_Name="Pencil",Product_Description="Hb Pencil",Ean="5 54353 2123",ExpectedRestock=true,BrandId=2,BrandName="Stadt",CategoryId=2,CategoryName="Stationary",Price=2.33,Original_Price=3.00 },
                new Product_table2{ID=3,Product_Name="Glass",Product_Description="HOmeware Glass",Ean="3 34324 2341",ExpectedRestock=false,BrandId=3,BrandName="Homebase",CategoryId=3,CategoryName="Homeware",Price=3.45,Original_Price=5.88 }
            };


            Assert.AreEqual(expected,new ContentUpdater().checkforUpdates(oldlist,newList));
        }

        [TestMethod()]
        public void getAllproductsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void buildlistwcfTest()
        {
            List<Product_table2> expected = new List<Product_table2>()
            {
                new Product_table2{ID=1,Product_Name="Cloth Cover",Product_Description="Lamely adapted used and dirty teatowel.  Guaranteed fewer than two holes.",Ean="5 102310 300103",ExpectedRestock=null,Price=2.6,Original_Price=2.6,CategoryId=3,CategoryName="Covers", },
                new Product_table2{ID=2,Product_Name="Harden Sponge Case",Product_Description="Especially toughen and harden sponge entirely encases your device to prevent any interaction.",Ean="5 102310 100204",ExpectedRestock=null,Price=8.3,Original_Price=8.3,CategoryId=4,CategoryName="Case" },
                new Product_table2{ID=3,Product_Name="Real Pencil Stylus",Product_Description="Stengthen HB pencils guaranteed to leave a mark.",Ean="5 102310 200308",ExpectedRestock=null,Price=1.02,Original_Price=1.02,CategoryId=1,CategoryName="Accessories" }
            };

            Assert.AreEqual(expected, cu.buildlistwcf(0));
        }

        [TestMethod()]
        public void buildListTest()
        {
            WebClient client = new WebClient();
            client.Headers.Add("Content-Type:application/json");
            client.Headers.Add("Accept:application/json");
            Assert.Fail();
        }

        [TestMethod()]
        public void insertDataTest()
        {
            IProductRepository ProdRepo = new IProductRepository(new ProdDB());

            
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