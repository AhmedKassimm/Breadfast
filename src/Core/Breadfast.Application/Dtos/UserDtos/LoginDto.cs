using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadfast.Application.Dtos.UserDtos
{
    public sealed record LoginDto(
        [Required][EmailAddress]string Email,
        [Required]string Password);
    
}
