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
    }
}
