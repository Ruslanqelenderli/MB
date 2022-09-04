using MB.Business.Abstract.BaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Concrete.DTOs
{
    public class CategoryDto:BaseDto
    {
        public string Name { get; set; }
        public ICollection<ProductDto> ProductDtos { get; set; }

    }
}
