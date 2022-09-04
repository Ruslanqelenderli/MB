using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Concrete.DTOs.ProductDtos
{
    public class ProductAddDto
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public int Count { get; set; }
        public Guid CategoryId { get; set; }
        public Guid AppUserId { get; set; }
    }
}
