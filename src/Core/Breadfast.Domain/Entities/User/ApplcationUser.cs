using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadfast.Domain.Entities.User
{
    public class ApplcationUser : IdentityUser
    {

        public string DisplayName { get; set; } = default!;
        public Address? Address { get; set; }


    }
}
