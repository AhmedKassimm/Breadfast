using Breadfast.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadfast.Domain.Interfaces.Service.Interface
{
    public interface IAuthService
    {

        Task<string> CreateTokenAsync(ApplcationUser user, UserManager<ApplcationUser> userManager);
    }
}
