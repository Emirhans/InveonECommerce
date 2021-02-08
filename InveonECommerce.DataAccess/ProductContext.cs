using InveonECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonECommerce.DataAccess
{
    public class ProductContext:DbContext
    {
        public ProductContext():base("ProductContext")
        {

        }

     
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }
}
