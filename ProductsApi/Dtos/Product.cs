﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsApi.Dtos
{
    public class Product
    {
        public int? BrandId { get; set; }

        public string BrandName { get; set; }

        public int? CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Product_Description { get; set; }

        public string Ean { get; set; }

        public bool? ExpectedRestock { get; set; }

        public string Product_Name { get; set; }

        public int ID { get; set; }

        public double Price { get; set; }

        public double Original_Price { get; set; }
    }
}