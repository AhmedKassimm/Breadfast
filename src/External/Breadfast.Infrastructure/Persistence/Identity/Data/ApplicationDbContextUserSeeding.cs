using Breadfast.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadfast.Infrastructure.Persistence.Identity.Data
{
    public static class ApplicationDbContextUserSeeding
    {

        public static async Task SeedUserAsync(UserManager<ApplcationUser> userManager)
        {

            if(userManager.Users.Count()<=0 )
            {
            var user = new ApplcationUser()
            {
                DisplayName = "Ahmed Kassim",
                Email = "ahmeedkassimm@gmail.com",
                UserName = "Ahmed.Kassim",
                PhoneNumber = "01026387356"

            };
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }

    }
}
