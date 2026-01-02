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
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    { 
           public void Configure(EntityTypeBuilder<Product> builder)
           {

               builder.Property(P => P.Description).HasColumnType(SqlServerDataTypes.Bigvarchar).IsRequired();
               builder.Property(P => P.Name).HasColumnType(SqlServerDataTypes.Varchar).IsRequired();
               builder.HasOne(P => P.Brand).WithMany().HasForeignKey(P=> P.BrandId);
               builder.HasOne(P => P.Category).WithMany().HasForeignKey(P=> P.CategoryId);
               builder.Property(P => P.Price).HasColumnType(SqlServerDataTypes.Decimal).IsRequired();
 
           }
    }
}
