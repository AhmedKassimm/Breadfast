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
    internal class ProductBrandConfigurations : IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.Property(B => B.Name).HasColumnType(SqlServerDataTypes.Shortvarchar).IsRequired();
        }
    }
}
