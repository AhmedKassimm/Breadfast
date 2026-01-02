using Breadfast.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Breadfast.Infrastructure.Persistence.Data.Database
{
    public class BreadfastDbContext : DbContext
    {

        public BreadfastDbContext(DbContextOptions<BreadfastDbContext> options) :base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


        public  DbSet<Product> Products { get; set; }
        public  DbSet<ProductBrand> Brands { get; set; }
        public  DbSet<ProductCategory> Categories { get; set; }

    }
}
