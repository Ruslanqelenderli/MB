
using MB.UI.Models.DTOs.BaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.UI.Models.DTOs
{
    public class AppRoleDto:BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<AppUserDto> AppUserDtos { get; set; }

    }
}
