using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadfast.Application.Dtos.UserDtos
{
    public sealed record UserDto(string userName, string email, string token);
    
}
