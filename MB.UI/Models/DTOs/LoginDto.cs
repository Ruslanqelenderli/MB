using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.UI.Models.DTOs
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }
        [Required]

        public string Password { get; set; }
    }

    public class LoginResultDto
    {
        public Guid Id { get; set; }
        public bool Result { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}
