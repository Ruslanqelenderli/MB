using MB.Entity.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Entity.Entities.Identity
{
    public class AppUser:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Guid AppRoleId { get; set; }
        public AppRole AppRole { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
