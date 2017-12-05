using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Configuration;
using System.Data.SqlClient;
using ProductRepository;
using DatabaseLayer;
using System.Collections;
using Content_Updater.bazzasbazaar;
using System.Timers;
using System.IO;

namespace Content_Updater
{
    class Program
    {

        static List<Product_table2> prodlist;

        static void Main(string[] args)
        {
            List<String> urilist = new List<string> { "http://dodgydealers.azurewebsites.net/api/product", "http://undercutters.azurewebsites.net/api/product" };
            ContentUpdater cu = new ContentUpdater(urilist);
            cu.Run();
        }



    }
}
