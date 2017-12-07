using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRepository
{
    public class IProductRepository : IRepository, IDisposable
    {
        private ProdDB context;

        public IProductRepository(ProdDB context)
        {
            this.context = context;
        }

        public void insertProduct(Product_table2 product)
        {
            context.Product_table2.Add(product);
            context.SaveChanges();
        }

        public List<Product_table2> getProducts()
        {
            return context.Product_table2.ToList();
        }

        public List<Orders> getOrders()
        {
            return context.Orders_Table.ToList();    
        }

        public void dropData()
        {
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE Product_table2");
        }

        public List<Product_table2> getProductsByBrandId(int? id)
        {
            return context.Product_table2.Where(p => p.BrandId == id).ToList();
        }
        public List<Product_table2> getProductsByCatId(int? id)
        {
            return context.Product_table2.Where(p => p.CategoryId == id).ToList();
        }
        public List<Product_table2> getProductsByString(string term)
        {
            return context.Product_table2.Where(p => p.Product_Name.Contains(term) || p.BrandName.Contains(term) || p.CategoryName.Contains(term)).ToList();
        }
        public List<Product_table2> getProductsMaxPrice(double price)
        {
            return context.Product_table2.Where(p => p.Price < price).ToList();
        }
        public List<Product_table2> getProductsMinPrice(double price)
        {
            return context.Product_table2.Where(p => p.Price > price).ToList();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
