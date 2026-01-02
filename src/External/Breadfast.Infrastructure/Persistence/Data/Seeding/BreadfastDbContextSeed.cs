using Breadfast.Domain.Entities.Products;
using Breadfast.Infrastructure.Persistence.Data.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Breadfast.Infrastructure.Persistence.Data.Seeding
{
    public static class BreadfastDbContextSeed
    {

        public static async Task SeedAsync(BreadfastDbContext _dbContext)
        { 
            if (_dbContext.Brands.Count() == 0)
            {
                var brandData =  File.ReadAllText("../Breadfast.Infrastructure/Persistence/Data/Seeding/FileSeeding/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                if (brands?.Count() > 0)
                {
                    foreach (var brand in brands)
                    {
                        _dbContext.Add(brand);
                    }
                  _dbContext.SaveChanges();
  
                }

            }

            if (_dbContext.Categories.Count() == 0)
            {
                var categoisData = File.ReadAllText("../Breadfast.Infrastructure/Persistence/Data/Seeding/FileSeeding/categories.json");
                var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoisData);
                if (categories?.Count() > 0)
                {
                    foreach (var category in categories)
                    {
                        _dbContext.Add(category);
                        _dbContext.SaveChanges();
                    }

                }

            }
            if (_dbContext.Products.Count() == 0)
            {
                var productData = File.ReadAllText("../Breadfast.Infrastructure/Persistence/Data/Seeding/FileSeeding/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productData);
                if (products?.Count() > 0)
                {
                    foreach (var product in products)
                    {
                        _dbContext.Add(product);
                        _dbContext.SaveChanges();
                    }

                }

            }


        }

}
  }