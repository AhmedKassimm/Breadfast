using Breadfast.Domain.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadfast.Infrastructure.Persistence.Identity.Data
{
     public class ApplicationIdentityDbContext :IdentityDbContext<ApplcationUser>
     {

        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options):base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Address> Addresses { get; set; }
    }
}
