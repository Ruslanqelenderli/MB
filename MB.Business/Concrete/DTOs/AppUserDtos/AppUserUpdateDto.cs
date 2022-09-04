using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Concrete.DTOs.AppUserDtos
{
    public class AppUserUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid AppRoleId { get; set; }
        public bool Status { get; set; }
    }
}
