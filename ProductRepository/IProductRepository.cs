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

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
