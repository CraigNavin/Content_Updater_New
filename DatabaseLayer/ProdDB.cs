namespace DatabaseLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections;

    public partial class ProdDB : DbContext
    {
        public ProdDB()
            : base("name=ProdDB")
        {
        }

        public virtual DbSet<Product_table2> Product_table2 { get; set; }
        public virtual DbSet<Orders> Orders_Table { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ProdDB>(new Dbinitializer());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product_table2>()
                .Property(e => e.BrandName)
                .IsUnicode(false);

            modelBuilder.Entity<Product_table2>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Product_table2>()
                .Property(e => e.Product_Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product_table2>()
                .Property(e => e.Ean)
                .IsUnicode(false);

            modelBuilder.Entity<Product_table2>()
                .Property(e => e.Product_Name)
                .IsUnicode(false);
        }
    }

    class Dbinitializer:CreateDatabaseIfNotExists<ProdDB>{

        protected override void Seed(ProdDB context)
        {
            var orders = new List<Orders>()
            {
                new Orders {OrderID = 1, prodID = 1, product_Name = "Sponge", price = 5.67, qty =2},
                new Orders {OrderID = 2, prodID = 2, product_Name = "Hat", price = 6.77, qty = 1},
                new Orders {OrderID = 3, prodID = 3, product_Name = "Cat", price = 76.87,qty = 1}
            };
            orders.ForEach(o => context.Orders_Table.Add(o));
            context.SaveChanges();
            base.Seed(context);
        }
        
    }

}
