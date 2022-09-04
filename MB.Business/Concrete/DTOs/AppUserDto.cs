using MB.Business.Abstract.BaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Concrete.DTOs
{
    public class AppUserDto:BaseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Guid AppRoleId { get; set; }
        public AppRoleDto AppRoleDto { get; set; }
        public ICollection<ProductDto> ProductDtos { get; set; }

    }
}
