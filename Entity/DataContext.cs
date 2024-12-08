using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GlobalShop.Entity
{
    public class DataContext:DbContext
    {
        public DataContext(): base("dataConnetion")
        {
           
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order>Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
       
    }
}