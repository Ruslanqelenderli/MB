using MB.Business.Abstract.BaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Concrete.DTOs
{
    public class ProductDto:BaseDto
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryDto CategoryDto { get; set; }
        public Guid AppUserId { get; set; }
        public AppUserDto AppUserDto { get; set; }
    }
}
