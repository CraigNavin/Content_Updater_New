using DatabaseLayer;
using ProductRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content_Updater
{
    class LegacyService
    {
        public void writeOrders()
        {

            List<Orders> orders = new IProductRepository(new ProdDB()).getOrders();
            Console.WriteLine("Legacy Service");
            string RootPath = Path.Combine(Path.GetFullPath(Directory.GetCurrentDirectory()), @"..\..\..\");
            foreach (Orders o in orders)
            {
                string path = Path.Combine(RootPath, o.product_Name + "Order.txt");
                if (File.Exists(path))
                {
                    Console.WriteLine(path + " Already Exists");
                }
                else
                {
                    string contents = string.Format(@"OrderID: {0} {5}" +
                        "ProductID: {1} {5}" +
                        "Product Name: {2} {5}" +
                        "Price: {3} {5}" +
                        "Qty: {4}", o.OrderID, o.prodID, o.product_Name, o.price, o.qty, Environment.NewLine);
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        tw.Write(contents);
                        Console.WriteLine(path + " Written to file");
                    }
                }

            }
        }
    }
}
