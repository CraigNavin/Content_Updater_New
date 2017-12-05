using Content_Updater.bazzasbazaar;
using DatabaseLayer;
using Newtonsoft.Json;
using ProductRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Content_Updater
{
    public class ContentUpdater
    {
        List<string> urilist;
        List<Product_table2> prodlist;
        IProductRepository ProdRepo = new IProductRepository(new ProdDB());

        public ContentUpdater(List<string> urilist)
        {
            this.urilist = urilist;
            prodlist = getAllproducts(urilist);
        }

        public  void OnTimedEvent(object sender, ElapsedEventArgs e, List<String> urilist)
        {
            prodlist = checkforUpdates(ProdRepo.getProducts(), getAllproducts(urilist));
            insertData(prodlist);

        }

        public List<Product_table2> checkforUpdates(List<Product_table2> oldList, List<Product_table2> newList)
        {

            List<Product_table2> updatedList = new List<Product_table2>();

            for (int i = 0; i < oldList.Count; i++)
            {

                if (oldList[i].Price != newList[i].Price)
                {
                    oldList[i].Price = newList[i].Price;
                }

                updatedList.Add(oldList[i]);

            }

            return updatedList;
        }

        public  List<Product_table2> getAllproducts(List<string> urilist)
        {

            int count = 0;
            int maxtries = 3;
            using (var client = new WebClient())
            {
                dynamic result = null;

                List<Product_table2> fullList = new List<Product_table2>();
                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");

                while (true)
                {
                    try
                    {
                        foreach (string address in urilist)
                        {
                            result = client.DownloadString(address);
                            fullList.AddRange(buildList(result, fullList.Count));
                            Console.WriteLine(address + " service completed");
                        }
                        fullList.AddRange(buildlistwcf(fullList.Count));
                        break;


                    }
                    catch (Exception e)
                    {
                        if (e is WebException)
                        {
                            WebException wex = (WebException)e;
                            if (wex.Status == WebExceptionStatus.ProtocolError)
                            {
                                if (((HttpWebResponse)wex.Response).StatusCode == HttpStatusCode.InternalServerError)
                                {
                                    Console.WriteLine("500: Server Error. Retrying now.");

                                }
                                else if (((HttpWebResponse)wex.Response).StatusCode == HttpStatusCode.ServiceUnavailable)
                                {
                                    Console.WriteLine("503: Service not available error. Retrying now.");
                                }

                                result = null;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Something went Wrong. Retrying now.");
                        }
                        if (count++ == maxtries)
                        {
                            Console.WriteLine("Max retries reached, exiting application");
                            Console.ReadLine();
                            break;
                        }

                    }
                }
                foreach (Product_table2 i in fullList)
                {
                    Console.WriteLine(ShowProduct(i));
                }
                Console.WriteLine(fullList.Count);


                return fullList;
                /*if (result != null)
                {
                    insertData(fullList);
                }
                else
                {
                    Console.WriteLine("Null List Passed");
                    Console.ReadLine();
                   
                }*/
            }

        }

        public  List<Product_table2> buildlistwcf(int listlen)
        {
            StoreClient wcf = new StoreClient();
            int getbyid = 1;
            List<Product_table2> list = new List<Product_table2>();
            Product_table2 product_Table2;
            do
            {
                try
                {
                    bazzasbazaar.Product product = wcf.GetProductById(getbyid);
                    product_Table2 = new Product_table2()
                    {
                        ID = product.Id + listlen,
                        BrandId = 0,
                        BrandName = "No Brand",
                        CategoryId = product.CategoryId,
                        CategoryName = product.CategoryName,
                        Product_Description = product.Description,
                        Ean = product.Ean,
                        ExpectedRestock = true,
                        Original_Price = product.PriceForOne,
                        Price = product.PriceForOne,
                        Product_Name = product.Name
                    };
                    list.Add(product_Table2);
                    getbyid++;
                }
                catch (Exception)
                {
                    Console.WriteLine("WCF service completed");
                    break;
                }

            } while (true);

            wcf.Close();
            return list;
        }

        public  void writeOrders()
        {

            List<Orders> orders = ProdRepo.getOrders();

            string OG_path = Path.Combine(Path.GetFullPath(Directory.GetCurrentDirectory()), @"..\..\");
            foreach (Orders o in orders)
            {
                string path = Path.Combine(OG_path, o.product_Name + "Order.txt");
                string contents = string.Format(@"OrderID: {0} {5}" +
                    "ProductID: {1} {5}" +
                    "Product Name: {2} {5}" +
                    "Price: {3} {5}" +
                    "Qty: {4}", o.OrderID, o.prodID, o.product_Name, o.price, o.qty, Environment.NewLine);
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.Write(contents);
                }

            }
        }

        public  List<Product_table2> buildList(dynamic json, int listlen)
        {
            List<Product_table2> list = new List<Product_table2>();
            var result2 = JsonConvert.DeserializeObject<List<Product>>(json);
            foreach (Product x in result2)
            {
                Product_table2 prod = new Product_table2()
                {
                    ID = x.ID + listlen,
                    Product_Name = x.Name,
                    Product_Description = x.Description,
                    Price = x.Price,
                    Original_Price = x.Price,
                    Ean = x.Ean,
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName,
                    BrandId = x.BrandId,
                    BrandName = x.BrandName,

                };
                if (x.ExpectedRestock.Equals(""))
                {
                    prod.ExpectedRestock = true;
                }
                else
                {
                    prod.ExpectedRestock = false;
                }

                list.Add(prod);
            }
            return list;
        }

        public  void insertData(List<Product_table2> list)
        {
            IProductRepository ProdRepo = new IProductRepository(new ProdDB());

            ProdRepo.dropData();

            foreach (Product_table2 prod in list)
            {
                ProdRepo.insertProduct(prod);
            }
        }

        public  string ShowProduct(Product_table2 prod)
        {
            Console.WriteLine();
            return "Product ID: " + prod.ID + "Product name: " + prod.Product_Name + " Product Desc: " + prod.Product_Description + " Product price " + prod.Price;
        }
    }
}

