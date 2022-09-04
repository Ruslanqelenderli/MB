using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.UI.Models.DTOs.AppUserDtos
{
    public class AppUserAddDto
    {
        [Required]
        public string Name { get; set; }
        [Required]

        public string Surname { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
