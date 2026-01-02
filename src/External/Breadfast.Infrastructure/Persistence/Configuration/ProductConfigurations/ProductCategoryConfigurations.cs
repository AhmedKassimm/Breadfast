using Breadfast.Domain.Entities.Products;
using Breadfast.Infrastructure.Persistence.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadfast.Infrastructure.Persistence.Configuration.ProductConfigurations
{
    internal class ProductCategoryConfigurations : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
           builder.Property(C => C.Name).IsRequired().HasColumnType(SqlServerDataTypes.Shortvarchar);
        }
    }
}
