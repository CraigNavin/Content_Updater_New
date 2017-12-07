using Microsoft.VisualStudio.TestTools.UnitTesting;
using Content_Updater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductRepository;
using DatabaseLayer;
using System.IO;

namespace Content_Updater.Tests
{
    [TestClass()]
    public class LegacyServiceTests
    {
        [TestMethod()]
        public void writeOrdersTest()
        {
            LegacyService ls = new LegacyService();
            ls.writeOrders();

            List<Orders> orders = new IProductRepository(new ProdDB()).getOrders();
            string RootPath = Path.Combine(Path.GetFullPath(Directory.GetCurrentDirectory()), @"..\..\..\");
            bool check;
            int count = 0;
            foreach (Orders o in orders)
            {
                string path = Path.Combine(RootPath, o.product_Name + "Order.txt");
                if (File.Exists(path))
                {
                    count++;
                }
            }
            if(count == 3)
            {
                check = true;
            }
            else
            {
                check = false;
            }
            Assert.IsTrue(check);
        }
    }
}