using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Concrete.DTOs
{
    public class LoginDto
    {
        public string Email { get; set; }
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
