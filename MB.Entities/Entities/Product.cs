using MB.Entity.Entities.Common;
using MB.Entity.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Entity.Entities
{
    public class Product:BaseEntity
    {
        public Product(){}
        
        public string Name { get; set; }
        public int Count { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public  Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
