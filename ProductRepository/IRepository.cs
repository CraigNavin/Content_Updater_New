using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRepository
{
    public interface IRepository
    {
        void insertProduct(Product_table2 prod);
        void dropData();
        List<Product_table2> getProducts();
        List<Orders> getOrders();
        List<Product_table2> getProductsByBrandId(int? id);
        List<Product_table2> getProductsByCatId(int? id);
        List<Product_table2> getProductsByString(string term);
        List<Product_table2> getProductsMaxPrice(double price);
        List<Product_table2> getProductsMinPrice(double price);
    }
}
