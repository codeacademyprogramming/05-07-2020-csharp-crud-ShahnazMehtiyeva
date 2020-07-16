namespace Task.Context
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Task.Models;

    public class ProductContext : DbContext
    {
      
        public ProductContext()
            : base("Server=DESKTOP-3MK75VA\\SQLEXPRESS; Database=Product; Trusted_Connection=True;")
        {
        }

        public DbSet<Product> Products { get; set; }
    }

}