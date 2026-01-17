using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadfast.Application.Dtos.UserDtos
{
    public class RegisterDto 
    {
        [Required]
        public string DisplayName { get; set; } = default!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;
        [Required]
        public string Password { get; set; } = default!;
        [Required]
        public string PhoneNumber { get; set; } = default!;

    }
}
