using MB.Entity.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Entity.Entities.Identity
{
    public class AppRole: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }
    }
}
